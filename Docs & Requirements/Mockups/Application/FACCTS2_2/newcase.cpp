#include "newcase.h"
#include "ui_newcase.h"
#include"qxmlputget.h"
#include"mainwindow.h"
#include <QDir>
#include <QDebug>

newCase::newCase(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::newCase)
{

    ui->setupUi(this);
}





//NEW CASE FILE CREATION

void newCase::on_toolButton_newCaseCreate_clicked()
{
//Create File Name from CaseID
    QString caseid;
    caseid = ui->lineEdit_caseNewID->text();

    QStringList orderfile;
    orderfile << "/users/jamesreid/cases/" << caseid << ".xml";
    QString newfile = orderfile.join("");

//Get Creation Date
    QString date = QDate::currentDate().toString("MM-dd-yyyy");
    QString empty = "";
    int a = 0;

//Write File

    QXmlPut xmlPut("caserecord");

//put caseHeader
    xmlPut.descend("caseheader");
    xmlPut.putString("caseNumber", caseid);
    xmlPut.putString("caseFileDate", date);
    xmlPut.putString("caseStatus", "New");
    xmlPut.rise();
    xmlPut.descend("parties");
//put party 1
    xmlPut.descend("party1");
    xmlPut.putString("p1FirstName", empty);
    xmlPut.putString("p1MiddleName", empty);
    xmlPut.putString("p1LastName", empty);
    xmlPut.putInt("p1Role", a);
    xmlPut.putInt("p1Designation", a);
    xmlPut.putString("p1Description", empty);
    xmlPut.putInt("p1Relationship", a);
    xmlPut.putInt("p1Hair", a);
    xmlPut.putInt("p1Eyes", a);
    xmlPut.putInt("p1Sex", a);
    xmlPut.putInt("p1Race", a);
    xmlPut.putString("p1Age", empty);
    xmlPut.putInt("p1Parentrole", a);
    xmlPut.putString("p1Weight", empty);
    xmlPut.putString("p1HeightFeet", empty);
    xmlPut.putString("p1HeightInch", empty);
    xmlPut.putString("p1DOB", empty);
    xmlPut.putString("p1AddressStreet", empty);
    xmlPut.putString("p1AddressCity", empty);
    xmlPut.putString("p1AddressState", empty);
    xmlPut.putString("p1AddressPostal", empty);
    xmlPut.putString("p1Phone", empty);
    xmlPut.putString("p1Fax", empty);
    xmlPut.putString("p1Email", empty);
    xmlPut.putBool("p1ProPer", true);
    xmlPut.putBool("p1Attorney", false);
    xmlPut.putString("p1AttorneyFirstName", empty);
    xmlPut.putString("p1AttorneyLastName", empty);
    xmlPut.putString("p1AttorneyBarID", empty);
    xmlPut.putString("p1AttorneyFirmName", empty);
    xmlPut.putString("p1AttorneyAddressStreet", empty);
    xmlPut.putString("p1AttorneyAddressCity", empty);
    xmlPut.putString("p1AttorneyAddressState", empty);
    xmlPut.putString("p1AttorneyAddressPostal", empty);
    xmlPut.putString("p1AttorneyPhone", empty);
    xmlPut.putString("p1AttorneyFax", empty);
    xmlPut.putString("p1AttorneyEmail", empty);

    xmlPut.rise();
//put party 2
    xmlPut.descend("party2");
    xmlPut.putString("p2FirstName", empty);
    xmlPut.putString("p2MiddleName", empty);
    xmlPut.putString("p2LastName", empty);
    xmlPut.putInt("p2Role", a);
    xmlPut.putInt("p2Designation", a);
    xmlPut.putString("p2Description", empty);
    xmlPut.putInt("p2Relationship", a);
    xmlPut.putInt("p2Hair", a);
    xmlPut.putInt("p2Eyes", a);
    xmlPut.putInt("p2Sex", a);
    xmlPut.putInt("p2Race", a);
    xmlPut.putString("p2Age", empty);
    xmlPut.putInt("p2Parentrole", a);
    xmlPut.putString("p2Weight", empty);
    xmlPut.putString("p2HeightFeet", empty);
    xmlPut.putString("p2HeightInch", empty);
    xmlPut.putString("p2DOB", empty);
    xmlPut.putString("p2AddressStreet", empty);
    xmlPut.putString("p2AddressCity", empty);
    xmlPut.putString("p2AddressState", empty);
    xmlPut.putString("p2AddressPostal", empty);
    xmlPut.putString("p2Phone", empty);
    xmlPut.putString("p2Fax", empty);
    xmlPut.putString("p2Email", empty);
    xmlPut.putBool("p2ProPer",true);
    xmlPut.putBool("p2Attorney", false);
    xmlPut.putString("p2AttorneyFirstName", empty);
    xmlPut.putString("p2AttorneyLastName", empty);
    xmlPut.putString("p2AttorneyBarID", empty);
    xmlPut.putString("p2AttorneyFirmName", empty);
    xmlPut.putString("p2AttorneyAddressStreet", empty);
    xmlPut.putString("p2AttorneyAddressCity", empty);
    xmlPut.putString("p2AttorneyAddressState", empty);
    xmlPut.putString("p2AttorneyAddressPostal", empty);
    xmlPut.putString("p2AttorneyPhone", empty);
    xmlPut.putString("p2AttorneyFax", empty);
    xmlPut.putString("p2AttorneyEmail", empty);
    xmlPut.rise();
    xmlPut.descend("party3");
    xmlPut.putBool("p3ProPer", false);
    xmlPut.putBool("p3RequestorAttorney", false);
    xmlPut.putString("p3AttorneyFirstName", empty);
    xmlPut.putString("p3AttorneyLastName", empty);
    xmlPut.putString("p3AttorneyBarID", empty);
    xmlPut.putString("p3AttorneyFirmName", empty);
    xmlPut.putString("p3AttorneyAddressStreet", empty);
    xmlPut.putString("p3AttorneyAddressCity", empty);
    xmlPut.putString("p3AttorneyAddressState", empty);
    xmlPut.putString("p3AttorneyAddressPostal", empty);
    xmlPut.putString("p3AttorneyPhone", empty);
    xmlPut.putString("p3AttorneyFax", empty);
    xmlPut.putString("p3AttorneyEmail", empty);
    xmlPut.rise();
    xmlPut.descend("childattorney");
    xmlPut.putString("c1AttorneyFirstName", empty);
    xmlPut.putString("c1AttorneyLastName", empty);
    xmlPut.putString("c1AttorneyBarID", empty);
    xmlPut.putString("c1AttorneyFirmName", empty);
    xmlPut.putString("c1AttorneyAddressStreet", empty);
    xmlPut.putString("c1AttorneyAddressCity", empty);
    xmlPut.putString("c1AttorneyAddressState", empty);
    xmlPut.putString("c1AttorneyAddressPostal", empty);
    xmlPut.putString("c1AttorneyPhone", empty);
    xmlPut.putString("c1AttorneyFax", empty);
    xmlPut.putString("c1AttorneyEmail", empty);
    xmlPut.rise();
    xmlPut.descend("children");
    xmlPut.descend("child1");
    xmlPut.putString("entity", empty);
    xmlPut.putString("firstname", empty);
    xmlPut.putString("lastname", empty);
    xmlPut.putString("relationship", empty);
    xmlPut.putString("dateofbirth", empty);
    xmlPut.putString("sex", empty);
    xmlPut.rise();
    xmlPut.descend("child2");
    xmlPut.putString("entity", empty);
    xmlPut.putString("firstname", empty);
    xmlPut.putString("lastname", empty);
    xmlPut.putString("relationship", empty);
    xmlPut.putString("dateofbirth", empty);
    xmlPut.putString("sex", empty);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("otherprotected");
    xmlPut.descend("otherprotected1");
    xmlPut.putString("entity", empty);
    xmlPut.putString("firstname", empty);
    xmlPut.putString("lastname", empty);
    xmlPut.putString("relationship", empty);
    xmlPut.putString("household", empty);
    xmlPut.putString("sex", empty);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("witness");
    xmlPut.descend("witness1");
    xmlPut.putString("entity", empty);
    xmlPut.putString("firstname", empty);
    xmlPut.putString("lastname", empty);
    xmlPut.putString("designation", empty);
    xmlPut.putString("witnessfor", empty);
    xmlPut.putString("contactinfo", empty);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("interpreter");
    xmlPut.descend("interpreter1");
    xmlPut.putString("entity", empty);
    xmlPut.putString("firstname", empty);
    xmlPut.putString("lastname", empty);
    xmlPut.putString("designation", empty);
    xmlPut.putString("interpreterfor", empty);
    xmlPut.putString("language", empty);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("relatedcases");
    xmlPut.descend("case1");
    xmlPut.putString("casenumber", empty);
    xmlPut.putString("casetype", empty);
    xmlPut.putString("county", empty);
    xmlPut.putString("CPOTRO", empty);
    xmlPut.putString("expirationdate", empty);
    xmlPut.putString("leadcase", empty);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("casehistory");
    xmlPut.descend("event1");
    xmlPut.putString("date", empty);
    xmlPut.putString("event", empty);
    xmlPut.putString("party1present", empty);
    xmlPut.putString("party1sworn", empty);
    xmlPut.putString("party1atty", empty);
    xmlPut.putString("party2present", empty);
    xmlPut.putString("party2sworn", empty);
    xmlPut.putString("party2atty", empty);
    xmlPut.putString("orders", empty);
    xmlPut.putString("mergedCase", empty);
    xmlPut.rise();
    xmlPut.descend("currentevent");
    xmlPut.putString("issuedate", empty);
    xmlPut.putString("expiredate", empty);
    xmlPut.putString("masterorder", empty);
    xmlPut.putString("attachedorders", empty);
    xmlPut.putString("overruns", empty);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("casenotes");
    xmlPut.descend("user1");
    xmlPut.putString("userid", "Sophia Myles");
    xmlPut.putString("userrole", "Court Admin");
    xmlPut.putString("lastdate", empty);
    xmlPut.putString("publicnotes", empty);
    xmlPut.putString("privatenotes", empty);
    xmlPut.rise();
    xmlPut.descend("user2");
    xmlPut.putString("userid", "Pascal Hutton");
    xmlPut.putString("userrole", "Court Clerk");
    xmlPut.putString("lastdate", empty);
    xmlPut.putString("publicnotes", empty);
    xmlPut.putString("privatenotes", empty);
    xmlPut.rise();
    xmlPut.descend("user3");
    xmlPut.putString("userid", "Ray Stevenson");
    xmlPut.putString("userrole", "Court Clerk");
    xmlPut.putString("lastdate", empty);
    xmlPut.putString("publicnotes", empty);
    xmlPut.putString("privatenotes", empty);
    xmlPut.rise();
    xmlPut.descend("user4");
    xmlPut.putString("userid", "Amy Smart");
    xmlPut.putString("userrole", "Court Admin");
    xmlPut.putString("lastdate", empty);
    xmlPut.putString("publicnotes", empty);
    xmlPut.putString("privatenotes", empty);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.rise();

// WRITE FILE
    xmlPut.save(newfile);
// ADD TO CASE LIST




// CLOSE WINDOW
    close();
}



newCase::~newCase()
{
    delete ui;
}

