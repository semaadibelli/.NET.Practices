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

