/*

Mail adresinize mail alabilmek için,
https://myaccount.google.com/lesssecureapps
Buradan izin ver,
dene
werwe
*/

//contact-form classındaki bilgileri alma kontrolü, alıyorsa submitForm fonksiyonuna gider.
var el=document.querySelector(".contact-form");
if(el){

    el.addEventListener("submit",submitForm);
}
else {
    console.log(names)
    console.log("contact-form okunamadı");
}


// İnputlardan gelen bilgileri değişkene atıp içeriği sıfırlıyoruz ve sendEmail adlı fonksiyona gönderiyoruz.
function submitForm(e){
    e.preventDefault();

    //Get İnput Values

    let name = document.querySelector(".username").value;
    console.log(name)
    let email = document.querySelector(".email").value;
    console.log(email)
    let message = document.querySelector(".message").value;
    console.log(message)
    document.querySelector(".contact-form").reset();

    sendEmail(name, email, message);

}
 

// Mail gönderimi için gerekli ayarlar ve mesaj kısmı hazırlanıyor, mesaj iletildiğinde alert ile uyarı veriyor.
function sendEmail(name, email, message){
    Email.send({
        Host: "smtp.gmail.com",
        Username: "alikader123.123@gmail.com",
        Password: "alikeser",
        To: "alikader123.123@gmail.com",
        From: "alikader123.123@gmail.com",
        Subject: `${name} sent you a message`,
        Body: `Gonderen: ${name} <br/> İletisim: ${email} <br/> Mesaj: ${message}`,

    }).then((message) => alert("Mesajiniz iletilmistir."));




}