#include "addparties.h"
#include "ui_addparties.h"

addparties::addparties(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::addparties)
{
    ui->setupUi(this);

    GetDefaultPartyInfo();
}


void addparties::AddRootParties(QString entity, QString fname, QString lname, QString designation, QString party, QString contact, QString present)
{
    QTreeWidgetItem *itm = new QTreeWidgetItem(ui->treeWidget_allParties);
    itm->setText(0,entity);
    itm->setText(1,fname);
    itm->setText(2,lname);
    itm->setText(3,designation);
    itm->setText(4,party);
    itm->setText(5,contact);
    itm->setText(6,present);
    ui->treeWidget_allParties->addTopLevelItem(itm);
}

void addparties::GetDefaultPartyInfo()
{
    QString orderid;
    orderid = ui->lineEdit_caseNumber->text();

    QStringList caseid;
    caseid << "/users/jamesreid/cases/" << orderid << ".xml";
    QString loadfile = caseid.join("");

    QString otherprotected = "Other Protected";
    QString child = "Children";
    QString witness = "Witness";
    QString interpreter = "Interpreter";
    QString none = "None";
    QString str1;
    QString str2;
    QString str3;
    QString str4;
    QString str5;
    QString str6;
    QString str7;
    QString str8;
    QString str9;
    QString str10;
    QString str11;
    QString str12;
    QString str13;
    QString str14;
    QString str15;
    QString str16;
    QString str17;
    QString str18;
    QString str19;
    QString str20;
    QString str21;
    QString str22;
    QString str23;
    QString str24;
    QString str25;
//Grab Party Info
    QXmlGet xmlGet;
    xmlGet.load(loadfile);

    xmlGet.find("caserecord");
    xmlGet.descend();
    xmlGet.find("parties");
    xmlGet.descend();
    xmlGet.find("children");
    xmlGet.descend();
    xmlGet.find("child1");
    xmlGet.descend();
    xmlGet.find("entity");
    str1 = xmlGet.getString();
    xmlGet.find("firstname");
    str2 = xmlGet.getString();
    xmlGet.find("lastname");
    str3 = xmlGet.getString();
    xmlGet.find("relationship");
    str4 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.find("child2");
    xmlGet.descend();
    xmlGet.find("entity");
    str5 = xmlGet.getString();
    xmlGet.find("firstname");
    str6 = xmlGet.getString();
    xmlGet.find("lastname");
    str7 = xmlGet.getString();
    xmlGet.find("relationship");
    str8 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("witness");
    xmlGet.descend();
    xmlGet.find("witness1");
    xmlGet.descend();
    xmlGet.find("entity");
    str9 = xmlGet.getString();
    xmlGet.find("firstname");
    str10 = xmlGet.getString();
    xmlGet.find("lastname");
    str11 = xmlGet.getString();
    xmlGet.find("designation");
    str12 = xmlGet.getString();
    xmlGet.find("witnessfor");
    str13 = xmlGet.getString();
    xmlGet.find("contactinfo");
    str14 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.find("witness2");
    xmlGet.descend();
    xmlGet.find("entity");
    str15 = xmlGet.getString();
    xmlGet.find("firstname");
    str16 = xmlGet.getString();
    xmlGet.find("lastname");
    str17 = xmlGet.getString();
    xmlGet.find("designation");
    str18 = xmlGet.getString();
    xmlGet.find("witnessfor");
    str19 = xmlGet.getString();
    xmlGet.find("contactinfo");
    str20 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("interpreter");
    xmlGet.descend();
    xmlGet.find("interpreter1");
    xmlGet.descend();
    xmlGet.find("entity");
    str21 = xmlGet.getString();
    xmlGet.find("firstname");
    str22 = xmlGet.getString();
    xmlGet.find("lastname");
    str23 = xmlGet.getString();
    xmlGet.find("designation");
    str24 = xmlGet.getString();
    xmlGet.find("interpreterfor");
    str25 = xmlGet.getString();




//All Parties Table
    ui->treeWidget_allParties->setColumnCount(7);
    ui->treeWidget_allParties->setColumnWidth(0,80);
    ui->treeWidget_allParties->setColumnWidth(1,90);
    ui->treeWidget_allParties->setColumnWidth(2,90);
    ui->treeWidget_allParties->setColumnWidth(3,90);
    ui->treeWidget_allParties->setColumnWidth(4,130);
    ui->treeWidget_allParties->setColumnWidth(5,90);
    ui->treeWidget_allParties->setColumnWidth(6,70);
    ui->treeWidget_allParties->setHeaderLabels(QStringList() << "ENTITY" << "FIRST NAME" << "LAST NAME" << "DESIGNATION" << "PARTY FOR" << "CONTACT" << "PRESENT");
    AddRootParties(str1, str2, str3, str4, none, none, "No");
    AddRootParties(str5, str6, str7, str8, none, none, "No");
    AddRootParties(str9, str10, str11, str12, str13, str14, "Yes");
    AddRootParties(str15, str16, str17, str18, str19, str20, "Yes");
    AddRootParties(str21, str22, str23, str24, str25, none, "No");

}





addparties::~addparties()
{
    delete ui;
}
