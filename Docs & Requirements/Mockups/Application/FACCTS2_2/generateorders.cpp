#include "generateorders.h"
#include "ui_generateorders.h"
#include"qxmlputget.h"

generateOrders::generateOrders(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::generateOrders)
{

    ui->setupUi(this);


    LoadDocStack();

}


void generateOrders::SetOrderID(QString orderId)
{
    ui->lineEdit_caseNumber->setText(orderId);
}



void generateOrders::LoadDocStack()
{
    QString gen1;
    QString gen2;
    QString gen3;

    int ga;

//read File
    QXmlGet xmlGet;
    xmlGet.load("/users/jamesreid/caseorders/22-1251_order.xml");
    xmlGet.find("caseorders");
    xmlGet.descend();
    xmlGet.find("caseheader");
    xmlGet.descend();
    xmlGet.find("caseNumber");
    gen1 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.find("GenerateStack");
    xmlGet.descend();
    xmlGet.find("masterorder");
    ga = xmlGet.getInt();
    xmlGet.find("DV140");
    bool DV140 = xmlGet.getBool();
    xmlGet.find("DV145");
    bool DV145 = xmlGet.getBool();
    xmlGet.find("DV150");
    bool DV150 = xmlGet.getBool();
    xmlGet.find("FL340");
    bool FL340 = xmlGet.getBool();
    xmlGet.find("FL341");
    bool FL341 = xmlGet.getBool();
    xmlGet.find("FL342");
    bool FL342 = xmlGet.getBool();
    xmlGet.find("FL343");
    bool FL343 = xmlGet.getBool();
    xmlGet.find("OtherAttachment1");
    gen2 = xmlGet.getString();
    xmlGet.find("OtherAttachment2");
    gen3 = xmlGet.getString();
    xmlGet.find("DV730");
    bool DV730 = xmlGet.getBool();
    xmlGet.find("DV115");
    bool DV115 = xmlGet.getBool();
    xmlGet.find("DV116");
    bool DV116 = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.rise();

    ui->lineEdit_caseNumber->setText(gen1);
    ui->comboBox_masterOrder->setCurrentIndex(ga);
    ui->checkBox_generateDV140->setChecked(DV140);
    ui->checkBox_generateDV145->setChecked(DV145);
    ui->checkBox_generateDV150->setChecked(DV150);
    ui->checkBox_generateFL340->setChecked(FL340);
    ui->checkBox_generateFL341->setChecked(FL341);
    ui->checkBox_generateFL342->setChecked(FL342);
    ui->checkBox_generateFL343->setChecked(FL343);
    ui->lineEdit_otherAttach1->setText(gen2);
    ui->lineEdit_otherAttach2->setText(gen3);
    ui->checkBox_DV730->setChecked(DV730);
    ui->checkBox_DV115->setChecked(DV115);
    ui->checkBox_DV116->setChecked(DV116);
}

generateOrders::~generateOrders()
{
    delete ui;
}
