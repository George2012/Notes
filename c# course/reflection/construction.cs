var t = typeof(bool);
var b = Activator.CreateInstance(t);
b
// false

var b2 = Activator.CreateInstance<bool>();
b2
// false

var wc = Activator.CreateInstance("System", "System.Timers.Timer");
wc
// ObjectHandle { }

wc.Unwrap()
// [System.Timers.Timer]

var alType = Type.GetType("System.Collections.ArrayList");
alType
// [System.Collections.ArrayList]

var alCtor = alType.GetConstructor(Array.Empty<Type>());
alCtor
// [Void .ctor()]

var al = alCtor.Invoke(Array.Empty<object>());
al
// ArrayList(0) { }

var st = typeof(string);
var ctor = st.GetConstructor(new[]{ typeof(char[]) });
ctor
// [Void .ctor(Char[])]

var str = ctor.Invoke(new object[]
// * {

// *   new [] { 't', 'e', 's', 't' }
// * });
str
// "test"

var listType = Type.GetType("System.Collection.Generic.List`1");
listType
var listType = Type.GetType("System.Collections.Generic.List`1");
listType
// [System.Collections.Generic.List`1[T]]

var listOfIntType = listType.MakeGenericType(typeof(int));
listOfIntType
// [System.Collections.Generic.List`1[System.Int32]]

var listOfIntCtor = listOfIntType.GetConstructor(Array.Empty<Type>());
listOfIntCtor
// [Void .ctor()]

var theList = listOfIntCtor.Invoke(Array.Empty<object>());
theList
// List<int>(0) { }

var charType = typeof(char);
Array.CreateInstance(charType, 10)
// char[10] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

var charArrayType = charType.MakeArrayType();
charArrayType
// [System.Char[]]

charArrayType.FullName
// "System.Char[]"

var charArrayCtor = charArrayType.GetConstructor(new[]{ typeof(int) });
charArrayCtor
// [Void .ctor(Int32)]

var arr = charArrayCtor.Invoke(new object[]{20});
arr
// char[20] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

for (int i = 0; i < arr.Length; ++i)
// *   arr[i] = (char)('A' + i);

new string(arr)
arr
// char[20] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

arr.GetType().Name
// "Char[]"

char[] arr2 = (char[])arr;
arr2
// char[20] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

arr2[1] = 'Z';
arr2
// char[20] { '\0', 'Z', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

