#include <string>
#include <ostream>
#include <iostream>
#include <vector>
#include <sstream>

using namespace std;

struct Element
{
    string name;
    string type;

    Element(string _name, string _type)
        :name(_name), type(_type){}

    friend ostream& operator<<(ostream& os, const Element& elm)
    {
        return os << elm.name << " " << elm.type << ";";
    }
};

struct ListOfElements
{
    string name;
    vector<Element> elems;

    friend ostream& operator<<(ostream& os, const ListOfElements& listE)
    {
        os << listE.name << "{";

        for (auto&& elm : listE.elems)
        {
            os << elm << "\n";
        }

        os << "}";

        return os;
    }
};

class CodeBuilder
{
private:
    ListOfElements head;
public:
  CodeBuilder(const string& class_name)
  {
      head.name = class_name;
  }

  CodeBuilder& add_field(const string& name, const string& type)
  {
      head.elems.emplace_back(Element(name, type));
      return *this;
  }

  friend ostream& operator<<(ostream& os, const CodeBuilder& obj)
  {
      os << obj.head;
      return os;
  }
};

void CodeBuilderTest()
{
    auto cb = CodeBuilder{ "Person" }.add_field("name", "string").add_field("age", "int");
    ostringstream oss;
    oss << cb;
    auto printed = oss.str();
    cout << printed;
}