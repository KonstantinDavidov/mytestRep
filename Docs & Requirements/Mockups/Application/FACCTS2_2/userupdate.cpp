#include "userupdate.h"
#include "ui_userupdate.h"
#include "qxmlputget.h"
#include "mainwindow.h"

userupdate::userupdate(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::userupdate)
{
    ui->setupUi(this);
}

userupdate::~userupdate()
{
    delete ui;
}


void userupdate::AddUser()
{
    QString str1;
    QString str2;
    QString str3;
    QString str4;
    QString date = QDate::currentDate().toString("MM-dd-yyyy");

    str1=ui->lineEdit_firstNameAdd->text();
    str2=ui->lineEdit_middleNameAdd->text();
    str3=ui->lineEdit_lastNameAdd->text();
    str4=ui->lineEdit_eMailAdd->text();

    QStringList fullname;
    fullname << str1 << str3;
    QString userid = fullname.join(" ");

    QXmlGet xmlGet;
    xmlGet.load("/users/jamesreid/faccts_user.xml");
    xmlGet.findAndDescend("faccts");
    xmlGet.findAndDescend("userset");
    xmlGet.findAndDescend("user5");
    if (xmlGet.getAttributeBool("modifyme"))
    {
        QXmlPut xmlPut(xmlGet);
        xmlPut.putString("userid", userid);
        xmlPut.putString("firstname", str1);
        xmlPut.putString("middlename", str2);
        xmlPut.putString("lastname", str3);
        xmlPut.putString("createdate", date);
        xmlPut.setAttributeBool("active", false);
        xmlPut.putString("password", "");
        xmlPut.putString("userrole", "");
        xmlPut.putString("substitute", "");
        xmlPut.putString("userphone", "");
        xmlPut.putString("useremail", str4);
        xmlPut.putBool("userclets", false);
        xmlPut.putString("userimage", "");
        xmlPut.putBool("useravailable", false);
        xmlPut.rise();
        xmlPut.descend("user6");
        xmlPut.setAttributeBool("modifyme", true);
        xmlPut.rise();
        xmlPut.save("/users/jamesreid/faccts_user.xml");
    }

}




void userupdate::on_toolButton_addUser_clicked()
{
    AddUser();
}
