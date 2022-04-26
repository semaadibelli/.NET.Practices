console.log("2 ok");

// Operatörler
// Matematiksel operatörler
// + - * / %
// ++ -- ** (** : üzeri demek 2**3: 2 üzeri 3 demektir)
// += -= *= /= %=
// Mantıksal operatörler
// < > <= >= ==  ! != === !== && || & |
// && ile & arasında ki farkı çalış.
// || ile | arasında ki farkı çalış.
// ===: tipinide kontrol eder. 2=="2" true çıkarken 2==="2" false çıkar

function kontrol (){
    var a= 10;
    var b= "10";
    console.log("a = " + typeof a); // typeof nesnenin tipini verir
    console.log("b = " + typeof b);
    if(a==b && typeof(a) == typeofb){
        // === çalışma mantığı
        console.log("a=b");
    }
    else{
        console.log("a!=b");
    }// cevabı a=number b=string a!=b çıkar
    console.log(a+b); //cevabı 1010 çıkar
}

    // NaN: Not a Number
    // infinity: sonsuz

function faktoriyel(n){
    var sonuc = 1;
    for (var i = 1; i<= n ; i++){
        sonuc *=i;
    }
    return sonuc;
}

// Bir dizi içerisindeki elemanları for, forEach,map ile döndürmek
var array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
function diziDongu(){
    console.log("for")
    for(var i= 0; i<array.length; i++){
        var item = array[i];
        console.log(item);
    }
    console.log("forEach")
    array.forEach(item => {console.log(item);});

    console.log("map")
    array.map(item => {console.log(item);});
}

// arrow function
var diziDongu2 = () => {
    array.map((item, index, itself) => {
        console.log("Index: " + index + " Değer: " + item);
        console.log("itself: " + itself);       
    });
};
//----------------------------------------------------------------//
// bütün elemanları kontrol edip ilk tekrar edeni ekrana yazsın
var a=[1, 2, 3, 4, 5, 6, 6, 8, 9, 10, 2, 2]; // return 6
var b=[2, 4, 5, 3, 1, 1, 3, 4, 5, 5]; // return 1
// Hoca Çözüm
function checkRepeat(array) {
    var distinct = [];
    for (var i = 1; i < array.length; i++) {
        var item1 = array[i-1];
        var item2 = array[i];
        if (item1 == item2 && distinct.indexOf(item1) == -1) {
            distinct.push(item1);
        }
    }
    return distinct.toString();
  }
console.log(checkRepeat(a));
console.log(checkRepeat(b));

// Mert Çözüm
function firstRepeat(arr){
    var resArr = []

    for(let i=0; i<arr.length-1; i++){
        if(arr[i] === arr[i+1] && !resArr.includes(arr[i])){
            resArr.push(arr[i]);
            i++
        }
    }
    return resArr;
}
