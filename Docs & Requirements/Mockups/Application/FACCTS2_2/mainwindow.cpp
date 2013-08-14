#include"mainwindow.h"
#include"ui_mainwindow.h"
#include"userupdate.h"
#include"export.h"
#include"newcase.h"
#include"confirm.h"
#include"ordersave.h"
#include"adddocket.h"
#include"consolidate.h"
#include"reissue.h"
#include"seperate.h"
#include"continuance.h"
#include"casestatus.h"
#include"addrelatedcase.h"
#include"generateorders.h"
#include"renewcase.h"
#include"addparties.h"
#include"removedocket.h"
#include"casesave.h"
#include"qxmlputget.h"

#include <QDebug>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

//  SET CURRENT TIME AND DATE FOR DOCKET
    QString date = QDate::currentDate().toString("MMM dd yyyy");
    QString time = QTime::currentTime().toString("hh:mm:ss");
    ui->label_docketDate->setText(date);
    ui->label_ordersDate->setText(date);

// AUTO COMPLETE FUNCTIONS DAYS OF WEEK ENTRIES
    QStringList Weekdays;
    Weekdays << "Monday" << "Tuesday" << "Wednesday" << "Thursday" << "Friday";
    QStringList Weekends;
    Weekends << "Sunday" << "Saturday";
    WeekdayCompleter = new QCompleter(Weekdays, this);
    WeekdayCompleter->setCaseSensitivity(Qt::CaseInsensitive);
    ui->lineEdit_DV110VisitScheduleWeekdayStartDay->setCompleter(WeekdayCompleter);
    ui->lineEdit_DV110VisitScheduleWeekdayEndDay->setCompleter(WeekdayCompleter);
    ui->lineEdit_DV130ScheduleWeekdayStartDay->setCompleter(WeekdayCompleter);
    ui->lineEdit_DV130ScheduleWeekdayEndDay->setCompleter(WeekdayCompleter);

    WeekendCompleter = new QCompleter(Weekends, this);
    WeekendCompleter->setCaseSensitivity(Qt::CaseInsensitive);
    ui->lineEdit_DV110ScheduleWeekendStartDay->setCompleter(WeekendCompleter);
    ui->lineEdit_DV110ScheduleWeekendEndDay->setCompleter(WeekendCompleter);
    ui->lineEdit_DV130ScheduleWeekendStartDay->setCompleter(WeekendCompleter);
    ui->lineEdit_DV130ScheduleWeekendEndDay->setCompleter(WeekendCompleter);

//SET PROGRAM DEFAULTS - MOVE TO QSETTINGS IN NEXT VERSION
    SetDefaultsPrevious();
//LOAD DOCKET
    LoadNoDocketList();
//LOAD CONFIGURATION
    LoadConfiguration();
//LOAD SECURITY CONFIGURATION
    LoadSecurity();
//LOAD USER SET
    LoadUserSet();
}

MainWindow::~MainWindow()
{
    delete ui;
}

//SETUP CASE LISTS and DEFAULTS
void MainWindow::SetDefaultsPrevious()
{
    ui->listWidget_caseOrderList->setCurrentRow(0);
    ui->listWidget_listCaseRecord->setCurrentRow(0);
    ui->listWidget_caseDocket->setCurrentRow(0);
    ui->listWidget_caseStatusList->setCurrentRow(0);
    ui->listWidget_Orders_Stack->setCurrentRow(0);
    ui->listWidget_Record_Stack->setCurrentRow(0);
    int docket;
    docket = ui->listWidget_caseOrderList->count();
    ui->label_totalCases->setNum(docket);
    ui->listWidget_userList->setCurrentRow(0);
    ui->listWidget_userRoleList->setCurrentRow(0);
    ui->listWidget_userRoleList_2->setCurrentRow(0);
}


//PANEL FUNCTIONS
//ATTORNEY FOR CHILDREN
void MainWindow::on_toolButton_copyp1Attorney_clicked()
{
    QString str;
    str = ui->lineEdit_p1Attorney_FirstName->text();
    ui->lineEdit_c1Attorney_FirstName->setText(str);

    QString str2;
    str2 = ui->lineEdit_p1Attorney_LastName->text();
    ui->lineEdit_c1Attorney_LastName->setText(str2);

    QString str3;
    str3 = ui->lineEdit_p1Attorney_FirmName->text();
    ui->lineEdit_c1Attorney_FirmName->setText(str3);

    QString str4;
    str4 = ui->lineEdit_p1Attorney_BarID->text();
    ui->lineEdit_c1Attorney_BarID->setText(str4);

    QString str5;
    str5 = ui->lineEdit_p1Attorney_Phone->text();
    ui->lineEdit_c1Attorney_Phone->setText(str5);

    QString str6;
    str6 = ui->lineEdit_p1Attorney_Fax->text();
    ui->lineEdit_c1Attorney_Fax->setText(str6);

    QString str7;
    str7 = ui->lineEdit_p1Attorney_Email->text();
    ui->lineEdit_c1Attorney_Email->setText(str7);

    QString str8;
    str8 = ui->lineEdit_p1Attorney_AddressStreet->text();
    ui->lineEdit_c1Attorney_AddressStreet->setText(str8);

    QString str9;
    str9 = ui->lineEdit_p1Attorney_AddressCity->text();
    ui->lineEdit_c1Attorney_AddressCity->setText(str9);

    QString str10;
    str10 = ui->lineEdit_p1Attorney_AddressState->text();
    ui->lineEdit_c1Attorney_AddressState->setText(str10);

    QString str11;
    str11 = ui->lineEdit_p1Attorney_AddressPostal->text();
    ui->lineEdit_c1Attorney_AddressPostal->setText(str11);
}

void MainWindow::on_toolButton_copyp2Attorney_clicked()
{
    QString str12;
    str12 = ui->lineEdit_p2Attorney_FirstName->text();
    ui->lineEdit_c1Attorney_FirstName->setText(str12);

    QString str13;
    str13 = ui->lineEdit_p2Attorney_LastName->text();
    ui->lineEdit_c1Attorney_LastName->setText(str13);

    QString str14;
    str14 = ui->lineEdit_p2Attorney_FirmName->text();
    ui->lineEdit_c1Attorney_FirmName->setText(str14);

    QString str15;
    str15 = ui->lineEdit_p2Attorney_BarID->text();
    ui->lineEdit_c1Attorney_BarID->setText(str15);

    QString str16;
    str16 = ui->lineEdit_p2Attorney_Phone->text();
    ui->lineEdit_c1Attorney_Phone->setText(str16);

    QString str17;
    str17 = ui->lineEdit_p2Attorney_Fax->text();
    ui->lineEdit_c1Attorney_Fax->setText(str17);

    QString str18;
    str18 = ui->lineEdit_p2Attorney_Email->text();
    ui->lineEdit_c1Attorney_Email->setText(str18);

    QString str19;
    str19 = ui->lineEdit_p2Attorney_AddressStreet->text();
    ui->lineEdit_c1Attorney_AddressStreet->setText(str19);

    QString str20;
    str20 = ui->lineEdit_p2Attorney_AddressCity->text();
    ui->lineEdit_c1Attorney_AddressCity->setText(str20);

    QString str21;
    str21 = ui->lineEdit_p2Attorney_AddressState->text();
    ui->lineEdit_c1Attorney_AddressState->setText(str21);

    QString str22;
    str22 = ui->lineEdit_p2Attorney_AddressPostal->text();
    ui->lineEdit_c1Attorney_AddressPostal->setText(str22);
}

//DV110 VISITATION SCHEDULE
void MainWindow::on_toolButton_visitWeekendAll_clicked()
{
    ui->checkBox_DV110ScheduleWeekendMonth1->setChecked(true);
    ui->checkBox_DV110ScheduleWeekendMonth2->setChecked(true);
    ui->checkBox_DV110ScheduleWeekendMonth3->setChecked(true);
    ui->checkBox_DV110ScheduleWeekendMonth4->setChecked(true);
    ui->checkBox_DV110ScheduleWeekendMonth5->setChecked(true);
}

void MainWindow::on_toolButton_visitWeekendAlternate_clicked()
{
    ui->checkBox_DV110ScheduleWeekendMonth1->setChecked(true);
    ui->checkBox_DV110ScheduleWeekendMonth2->setChecked(false);
    ui->checkBox_DV110ScheduleWeekendMonth3->setChecked(true);
    ui->checkBox_DV110ScheduleWeekendMonth4->setChecked(false);
    ui->checkBox_DV110ScheduleWeekendMonth5->setChecked(true);
}

void MainWindow::on_toolButton_visitEvenWeekend_clicked()
{
    ui->checkBox_DV110ScheduleWeekendMonth1->setChecked(false);
    ui->checkBox_DV110ScheduleWeekendMonth2->setChecked(true);
    ui->checkBox_DV110ScheduleWeekendMonth3->setChecked(false);
    ui->checkBox_DV110ScheduleWeekendMonth4->setChecked(true);
    ui->checkBox_DV110ScheduleWeekendMonth5->setChecked(false);
}

//DV130 VISITATION SCHEDULE
void MainWindow::on_toolButton_visitDV130AllWeekend_clicked()
{
    ui->checkBox_DV130ScheduleWeekendMonth1->setChecked(true);
    ui->checkBox_DV130ScheduleWeekendMonth2->setChecked(true);
    ui->checkBox_DV130ScheduleWeekendMonth3->setChecked(true);
    ui->checkBox_DV130ScheduleWeekendMonth4->setChecked(true);
    ui->checkBox_DV130ScheduleWeekendMonth5->setChecked(true);
}
void MainWindow::on_toolButton_visitDV130OddWeekend_clicked()
{
    ui->checkBox_DV130ScheduleWeekendMonth1->setChecked(true);
    ui->checkBox_DV130ScheduleWeekendMonth2->setChecked(false);
    ui->checkBox_DV130ScheduleWeekendMonth3->setChecked(true);
    ui->checkBox_DV130ScheduleWeekendMonth4->setChecked(false);
    ui->checkBox_DV130ScheduleWeekendMonth5->setChecked(true);
}
void MainWindow::on_toolButton_visitDV130EvenWeekend_clicked()
{
    ui->checkBox_DV130ScheduleWeekendMonth1->setChecked(false);
    ui->checkBox_DV130ScheduleWeekendMonth2->setChecked(true);
    ui->checkBox_DV130ScheduleWeekendMonth3->setChecked(false);
    ui->checkBox_DV130ScheduleWeekendMonth4->setChecked(true);
    ui->checkBox_DV130ScheduleWeekendMonth5->setChecked(false);
}


void MainWindow::SaveCaseRecord()
{
// TEMP SAVE FILE BACKUP FOR CONFIRM DIALOG
     QString str100;
     QString str101;
     QString str102;
     QString str103;
     QString str104;
     QString str105;
     QString str106;
     QString str107;
     QString str108;
     QString str109;
     QString str110;
     QString str111;
     QString str112;
     QString str113;
     QString str114;
     QString str115;
     QString str116;
     QString str117;
     QString str118;
     QString str119;
     QString str120;
     QString str121;
     QString str122;
     QString str123;
     QString str124;
     QString str125;
     QString str126;
     QString str127;
     QString str128;
     QString str129;
     QString str130;
     QString str131;
     QString str132;
     QString str133;
     QString str134;
     QString str135;
     QString str136;
     QString str137;
     QString str138;
     QString str139;
     QString str140;
     QString str141;
     QString str142;
     QString str143;
     QString str144;
     QString str145;
     QString str146;
     QString str147;
     QString str148;
     QString str149;
     QString str150;
     QString str151;
     QString str152;
     QString str153;
     QString str154;
     QString str155;
     QString str156;
     QString str157;
     QString str158;
     QString str170;
     QString str171;
     QString str172;
     QString str173;
     QString str174;
     QString str175;
     QString str176;
     QString str177;
     QString str178;
     QString str179;
     QString str180;
     QString str181;
     QString str182;
     QString str183;
     QString str184;
     QString str185;
     QString str186;
     QString str187;
     QString str188;
     QString str189;
     QString str190;
     QString str191;
     QString str192;
     QString str193;
     QString str194;
     QString str195;
     QString str196;
     QString str197;
     QString str198;
     QString str199;
     QString str200;
     QString str201;
     QString str202;
     QString str203;
     QString str204;
     QString str205;
     QString str206;
     QString str207;
     QString str208;
     QString str209;
     QString str210;
     QString str211;
     QString str212;
     QString str213;
     QString str214;
     QString str215;
     QString str216;
     QString str217;
     QString str218;
     QString str219;
     QString str220;
     QString str221;
     QString str222;
     QString str223;
     QString str224;
     QString str225;
     QString str226;
     QString str227;
     QString str228;
     QString str229;
     QString str230;
     QString str231;
     QString str232;
     QString str233;
     QString str234;
     QString str235;
     QString str236;
     QString str237;
     QString str238;
     QString str239;
     QString str240;
     QString str241;
     QString str242;
     QString str243;
     QString str244;
     QString str245;
     QString str246;
     QString str247;
     QString str248;
     QString str249;
     QString str250;
     QString str251;
     QString str252;
     QString str253;
     QString str254;
     QString str255;
     QString str256;
     QString str257;
     QString str258;
     QString str259;
     QString str260;
     QString str261;
     QString str262;
     QString str263;
     QString str264;
     QString str265;
     QString str266;
     QString str267;
     QString str268;
     QString str269;
     QString str270;
     QString str271;
     QString str272;
     QString str273;
     QString str274;
     QString str275;
     QString str276;
     QString str277;
     QString str278;
     QString str279;
     QString str280;
     QString str281;
     QString str282;
     QString str283;
     QString str284;
     QString str285;
     QString str286;
     QString str287;
     QString str288;
     QString str289;
     QString str300;
     QString str301;
     QString str302;
     QString str303;
     QString str304;
     QString str305;
     QString str306;
     QString str307;
     QString str308;
     QString str309;
     QString str310;
     QString str311;
     QString str312;
     QString str313;
     QString str314;
     QString str315;
     QString str316;
     QString str317;
     QString str318;
     QString str319;
     QString str320;
     QString str321;

     int a, b, c, d, e, f, g, h, j, k, i, l, m, n, o ,p;

//ReadCaseHeader
    str154 = ui->lineEdit_caseNumber->text();
    str155 = ui->lineEdit_fileDate->text();
    str156 = ui->lineEdit_caseStatus->text();

//ReadParty1
    str100 = ui->lineEdit_p1FirstName->text();
    str101 = ui->lineEdit_p1MiddleName->text();
    str102 = ui->lineEdit_p1LastName->text();
    a = ui->comboBox_p1Role->currentIndex();
    b = ui->comboBox_p1Designation->currentIndex();
    str103 = ui->lineEdit_p1Description->text();
    c = ui->comboBox_p1Relationship->currentIndex();
    d = ui->comboBox_p1Hair->currentIndex();
    e = ui->comboBox_p1Eyes->currentIndex();
    f = ui->comboBox_p1Sex->currentIndex();
    g = ui->comboBox_p1Race->currentIndex();
    str104 = ui->lineEdit_p1Age->text();
    h = ui->comboBox_p1ParentRole->currentIndex();
    str105 = ui->lineEdit_p1Weight->text();
    str106 = ui->lineEdit_p1HeightFeet->text();
    str107 = ui->lineEdit_p1HeightInch->text();
    str108 = ui->lineEdit_p1DOB->text();
    str109 = ui->lineEdit_p1AddressStreet->text();
    str110 = ui->lineEdit_p1AddressCity->text();
    str111 = ui->lineEdit_p1AddressState->text();
    str112 = ui->lineEdit_p1AddressPostal->text();
    str113 = ui->lineEdit_p1Phone->text();
    str114 = ui->lineEdit_p1Fax->text();
    str115 = ui->lineEdit_p1Email->text();

//ReadParty2
    str127 = ui->lineEdit_p2FirstName->text();
    str128 = ui->lineEdit_p2MiddleName->text();
    str129 = ui->lineEdit_p2LastName->text();
    i = ui->comboBox_p2Role->currentIndex();
    j = ui->comboBox_p2Designation->currentIndex();
    str130 = ui->lineEdit_p2Description->text();
    k = ui->comboBox_p2Relationship->currentIndex();
    l = ui->comboBox_p2Hair->currentIndex();
    m = ui->comboBox_p2Eyes->currentIndex();
    n = ui->comboBox_p2Sex->currentIndex();
    o = ui->comboBox_p2Race->currentIndex();
    str131 = ui->lineEdit_p2Age->text();
    p = ui->comboBox_p2ParentRole->currentIndex();
    str132 = ui->lineEdit_p2Weight->text();
    str133 = ui->lineEdit_p2HeightFeet->text();
    str134 = ui->lineEdit_p2HeightInch->text();
    str135 = ui->lineEdit_p2DOB->text();
    str136 = ui->lineEdit_p2AddressStreet->text();
    str137 = ui->lineEdit_p2AddressCity->text();
    str138 = ui->lineEdit_p2AddressState->text();
    str139 = ui->lineEdit_p2AddressPostal->text();
    str140 = ui->lineEdit_p2Phone->text();
    str141 = ui->lineEdit_p2Fax->text();
    str142 = ui->lineEdit_p2Email->text();

//ReadAttorneys
    bool p1ProPer = ui->checkBox_p1Attorney_ProPer->checkState();
    bool p1Attorney = ui->checkBox_p1Attorney->checkState();
    str116 = ui->lineEdit_p1Attorney_FirstName->text();
    str117 = ui->lineEdit_p1Attorney_LastName->text();
    str118 = ui->lineEdit_p1Attorney_BarID->text();
    str119 = ui->lineEdit_p1Attorney_FirmName->text();
    str120 = ui->lineEdit_p1Attorney_AddressStreet->text();
    str121 = ui->lineEdit_p1Attorney_AddressCity->text();
    str122 = ui->lineEdit_p1Attorney_AddressState->text();
    str123 = ui->lineEdit_p1Attorney_AddressPostal->text();
    str124 = ui->lineEdit_p1Attorney_Phone->text();
    str125 = ui->lineEdit_p1Attorney_Fax->text();
    str126 = ui->lineEdit_p1Attorney_Email->text();
    bool p2ProPer = ui->checkBox_p2Attorney_ProPer->checkState();
    bool p2Attorney = ui->checkBox_p2Attorney->checkState();
    str143 = ui->lineEdit_p2Attorney_FirstName->text();
    str144 = ui->lineEdit_p2Attorney_LastName->text();
    str145 = ui->lineEdit_p2Attorney_BarID->text();
    str146 = ui->lineEdit_p2Attorney_FirmName->text();
    str147 = ui->lineEdit_p2Attorney_AddressStreet->text();
    str148 = ui->lineEdit_p2Attorney_AddressCity->text();
    str149 = ui->lineEdit_p2Attorney_AddressState->text();
    str150 = ui->lineEdit_p2Attorney_AddressPostal->text();
    str151 = ui->lineEdit_p2Attorney_Phone->text();
    str152 = ui->lineEdit_p2Attorney_Fax->text();
    str153 = ui->lineEdit_p2Attorney_Email->text();

    bool p3ProPer = ui->checkBox_p3Attorney_ProPer->checkState();
    str300 = ui->lineEdit_p3Attorney_FirstName->text();
    str301 = ui->lineEdit_p3Attorney_LastName->text();
    str302 = ui->lineEdit_p3Attorney_BarID->text();
    str303 = ui->lineEdit_p3Attorney_FirmName->text();
    str304 = ui->lineEdit_p3Attorney_AddressStreet->text();
    str305 = ui->lineEdit_p3Attorney_AddressCity->text();
    str306 = ui->lineEdit_p3Attorney_AddressState->text();
    str307 = ui->lineEdit_p3Attorney_AddressPostal->text();
    str308 = ui->lineEdit_p3Attorney_Phone->text();
    str309 = ui->lineEdit_p3Attorney_Fax->text();
    str310 = ui->lineEdit_p3Attorney_Email->text();

    str311 = ui->lineEdit_c1Attorney_FirstName->text();
    str312 = ui->lineEdit_c1Attorney_LastName->text();
    str313 = ui->lineEdit_c1Attorney_BarID->text();
    str314 = ui->lineEdit_c1Attorney_FirmName->text();
    str315 = ui->lineEdit_c1Attorney_AddressStreet->text();
    str316 = ui->lineEdit_c1Attorney_AddressCity->text();
    str317 = ui->lineEdit_c1Attorney_AddressState->text();
    str318 = ui->lineEdit_c1Attorney_AddressPostal->text();
    str319 = ui->lineEdit_c1Attorney_Phone->text();
    str320 = ui->lineEdit_c1Attorney_Fax->text();
    str321 = ui->lineEdit_c1Attorney_Email->text();

//User Case Notes
    str274 = ui->lineEdit_CaseNoteUserName1->text();
    str275 = ui->lineEdit_CaseNoteUserRole1->text();
    str276 = ui->lineEdit_CaseNoteLastDate1->text();
    str278 = ui->lineEdit_CaseNoteUserName2->text();
    str279 = ui->lineEdit_CaseNoteUserRole2->text();
    str280 = ui->lineEdit_CaseNoteLastDate2->text();
    str282 = ui->lineEdit_CaseNoteUserName3->text();
    str283 = ui->lineEdit_CaseNoteUserRole3->text();
    str284 = ui->lineEdit_CaseNoteLastDate3->text();
    str286 = ui->lineEdit_CaseNoteUserName4->text();
    str287 = ui->lineEdit_CaseNoteUserRole4->text();
    str288 = ui->lineEdit_CaseNoteLastDate4->text();
    str277 = ui->textEdit_NoteUser1->toPlainText();
    str278 = ui->textEdit_NoteUser2->toPlainText();
    str279 = ui->textEdit_NoteUser3->toPlainText();
    str280 = ui->textEdit_NoteUser4->toPlainText();

    QXmlPut xmlPut("caserecord");

//put caseHeader
    xmlPut.descend("caseheader");
    xmlPut.putString("caseNumber", str154);
    xmlPut.putString("caseFileDate", str155);
    xmlPut.putString("caseStatus", str156);
    xmlPut.rise();
    xmlPut.descend("parties");
//put party 1
    xmlPut.descend("party1");
    xmlPut.putString("p1FirstName", str100);
    xmlPut.putString("p1MiddleName", str101);
    xmlPut.putString("p1LastName", str102);
    xmlPut.putInt("p1Role", a);
    xmlPut.putInt("p1Designation", b);
    xmlPut.putString("p1Description", str103);
    xmlPut.putInt("p1Relationship", c);
    xmlPut.putInt("p1Hair", d);
    xmlPut.putInt("p1Eyes", e);
    xmlPut.putInt("p1Sex", f);
    xmlPut.putInt("p1Race", g);
    xmlPut.putString("p1Age", str104);
    xmlPut.putInt("p1Parentrole", h);
    xmlPut.putString("p1Weight", str105);
    xmlPut.putString("p1HeightFeet", str106);
    xmlPut.putString("p1HeightInch", str107);
    xmlPut.putString("p1DOB", str108);
    xmlPut.putString("p1AddressStreet", str109);
    xmlPut.putString("p1AddressCity", str110);
    xmlPut.putString("p1AddressState", str111);
    xmlPut.putString("p1AddressPostal", str112);
    xmlPut.putString("p1Phone", str113);
    xmlPut.putString("p1Fax", str114);
    xmlPut.putString("p1Email", str115);
    xmlPut.putBool("p1ProPer", p1ProPer);
    xmlPut.putBool("p1Attorney", p1Attorney);
    xmlPut.putString("p1AttorneyFirstName", str116);
    xmlPut.putString("p1AttorneyLastName", str117);
    xmlPut.putString("p1AttorneyBarID", str118);
    xmlPut.putString("p1AttorneyFirmName", str119);
    xmlPut.putString("p1AttorneyAddressStreet", str120);
    xmlPut.putString("p1AttorneyAddressCity", str121);
    xmlPut.putString("p1AttorneyAddressState", str122);
    xmlPut.putString("p1AttorneyAddressPostal", str123);
    xmlPut.putString("p1AttorneyPhone", str124);
    xmlPut.putString("p1AttorneyFax", str125);
    xmlPut.putString("p1AttorneyEmail", str126);
    xmlPut.rise();
//put party 2
    xmlPut.descend("party2");
    xmlPut.putString("p2FirstName", str127);
    xmlPut.putString("p2MiddleName", str128);
    xmlPut.putString("p2LastName", str129);
    xmlPut.putInt("p2Role", i);
    xmlPut.putInt("p2Designation", j);
    xmlPut.putString("p2Description", str130);
    xmlPut.putInt("p2Relationship", k);
    xmlPut.putInt("p2Hair", l);
    xmlPut.putInt("p2Eyes", m);
    xmlPut.putInt("p2Sex", n);
    xmlPut.putInt("p2Race", o);
    xmlPut.putString("p2Age", str131);
    xmlPut.putInt("p2Parentrole", p);
    xmlPut.putString("p2Weight", str132);
    xmlPut.putString("p2HeightFeet", str133);
    xmlPut.putString("p2HeightInch", str134);
    xmlPut.putString("p2DOB", str135);
    xmlPut.putString("p2AddressStreet", str136);
    xmlPut.putString("p2AddressCity", str137);
    xmlPut.putString("p2AddressState", str138);
    xmlPut.putString("p2AddressPostal", str139);
    xmlPut.putString("p2Phone", str140);
    xmlPut.putString("p2Fax", str141);
    xmlPut.putString("p2Email", str142);
    xmlPut.putBool("p2ProPer", p2ProPer);
    xmlPut.putBool("p2Attorney", p2Attorney);
    xmlPut.putString("p2AttorneyFirstName", str143);
    xmlPut.putString("p2AttorneyLastName", str144);
    xmlPut.putString("p2AttorneyBarID", str145);
    xmlPut.putString("p2AttorneyFirmName", str146);
    xmlPut.putString("p2AttorneyAddressStreet", str147);
    xmlPut.putString("p2AttorneyAddressCity", str148);
    xmlPut.putString("p2AttorneyAddressState", str149);
    xmlPut.putString("p2AttorneyAddressPostal", str150);
    xmlPut.putString("p2AttorneyPhone", str151);
    xmlPut.putString("p2AttorneyFax", str152);
    xmlPut.putString("p2AttorneyEmail", str153);
    xmlPut.rise();
    xmlPut.descend("party3");
    xmlPut.putBool("p3ProPer", p3ProPer);
    xmlPut.putString("p3AttorneyFirstName", str300);
    xmlPut.putString("p3AttorneyLastName", str301);
    xmlPut.putString("p3AttorneyBarID", str302);
    xmlPut.putString("p3AttorneyFirmName", str303);
    xmlPut.putString("p3AttorneyAddressStreet", str304);
    xmlPut.putString("p3AttorneyAddressCity", str305);
    xmlPut.putString("p3AttorneyAddressState", str306);
    xmlPut.putString("p3AttorneyAddressPostal", str307);
    xmlPut.putString("p3AttorneyPhone", str308);
    xmlPut.putString("p3AttorneyFax", str309);
    xmlPut.putString("p3AttorneyEmail", str310);
    xmlPut.rise();
    xmlPut.descend("childattorney");
    xmlPut.putString("c1AttorneyFirstName", str311);
    xmlPut.putString("c1AttorneyLastName", str312);
    xmlPut.putString("c1AttorneyBarID", str313);
    xmlPut.putString("c1AttorneyFirmName", str314);
    xmlPut.putString("c1AttorneyAddressStreet", str315);
    xmlPut.putString("c1AttorneyAddressCity", str316);
    xmlPut.putString("c1AttorneyAddressState", str317);
    xmlPut.putString("c1AttorneyAddressPostal", str318);
    xmlPut.putString("c1AttorneyPhone", str319);
    xmlPut.putString("c1AttorneyFax", str320);
    xmlPut.putString("c1AttorneyEmail", str321);
    xmlPut.rise();
    xmlPut.descend("children");
    xmlPut.descend("child1");
    xmlPut.putString("entity", str170);
    xmlPut.putString("firstname", str171);
    xmlPut.putString("lastname", str172);
    xmlPut.putString("relationship", str173);
    xmlPut.putString("dateofbirth", str174);
    xmlPut.putString("sex", str175);
    xmlPut.rise();
    xmlPut.descend("child2");
    xmlPut.putString("entity", str176);
    xmlPut.putString("firstname", str177);
    xmlPut.putString("lastname", str178);
    xmlPut.putString("relationship", str179);
    xmlPut.putString("dateofbirth", str180);
    xmlPut.putString("sex", str181);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("otherprotected");
    xmlPut.descend("otherprotected1");
    xmlPut.putString("entity", str182);
    xmlPut.putString("firstname", str183);
    xmlPut.putString("lastname", str184);
    xmlPut.putString("relationship", str185);
    xmlPut.putString("household", str186);
    xmlPut.putString("sex", str187);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("witness");
    xmlPut.descend("witness1");
    xmlPut.putString("entity", str188);
    xmlPut.putString("firstname", str189);
    xmlPut.putString("lastname", str190);
    xmlPut.putString("designation", str191);
    xmlPut.putString("witnessfor", str192);
    xmlPut.putString("contactinfo", str193);
    xmlPut.rise();
    xmlPut.descend("witness2");
    xmlPut.putString("entity", str194);
    xmlPut.putString("firstname", str195);
    xmlPut.putString("lastname", str196);
    xmlPut.putString("designation", str197);
    xmlPut.putString("witnessfor", str198);
    xmlPut.putString("contactinfo", str199);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("interpreter");
    xmlPut.descend("interpreter1");
    xmlPut.putString("entity", str200);
    xmlPut.putString("firstname", str201);
    xmlPut.putString("lastname", str202);
    xmlPut.putString("designation", str203);
    xmlPut.putString("interpreterfor", str204);
    xmlPut.putString("language", str205);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("relatedcases");
    xmlPut.descend("case1");
    xmlPut.putString("casenumber", str206);
    xmlPut.putString("casetype", str207);
    xmlPut.putString("county", str208);
    xmlPut.putString("CPOTRO", str209);
    xmlPut.putString("expirationdate", str210);
    xmlPut.putString("leadcase", str211);
    xmlPut.rise();
    xmlPut.descend("case2");
    xmlPut.putString("casenumber", str212);
    xmlPut.putString("casetype", str213);
    xmlPut.putString("county", str214);
    xmlPut.putString("CPOTRO", str215);
    xmlPut.putString("expirationdate", str216);
    xmlPut.putString("leadcase", str217);
    xmlPut.rise();
    xmlPut.descend("case3");
    xmlPut.putString("casenumber", str218);
    xmlPut.putString("casetype", str219);
    xmlPut.putString("county", str220);
    xmlPut.putString("CPOTRO", str221);
    xmlPut.putString("expirationdate", str222);
    xmlPut.putString("leadcase", str223);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("casehistory");
    xmlPut.descend("event1");
    xmlPut.putString("date", str224);
    xmlPut.putString("event", str225);
    xmlPut.putString("party1present", str226);
    xmlPut.putString("party1sworn", str227);
    xmlPut.putString("party1atty", str228);
    xmlPut.putString("party2present", str229);
    xmlPut.putString("party2sworn", str230);
    xmlPut.putString("party2atty", str231);
    xmlPut.putString("orders", str232);
    xmlPut.putString("mergedCase", str233);
    xmlPut.rise();
    xmlPut.descend("event2");
    xmlPut.putString("date", str234);
    xmlPut.putString("event", str235);
    xmlPut.putString("party1present", str236);
    xmlPut.putString("party1sworn", str237);
    xmlPut.putString("party1atty", str238);
    xmlPut.putString("party2present", str239);
    xmlPut.putString("party2sworn", str240);
    xmlPut.putString("party2atty", str241);
    xmlPut.putString("orders", str242);
    xmlPut.putString("mergedCase", str243);
    xmlPut.rise();
    xmlPut.descend("event3");
    xmlPut.putString("date", str244);
    xmlPut.putString("event", str245);
    xmlPut.putString("party1present", str246);
    xmlPut.putString("party1sworn", str247);
    xmlPut.putString("party1atty", str248);
    xmlPut.putString("party2present", str249);
    xmlPut.putString("party2sworn", str250);
    xmlPut.putString("party2atty", str251);
    xmlPut.putString("orders", str252);
    xmlPut.putString("mergedCase", str253);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("event4");
    xmlPut.putString("date", str254);
    xmlPut.putString("event", str255);
    xmlPut.putString("party1present", str256);
    xmlPut.putString("party1sworn", str257);
    xmlPut.putString("party1atty", str258);
    xmlPut.putString("party2present", str259);
    xmlPut.putString("party2sworn", str260);
    xmlPut.putString("party2atty", str261);
    xmlPut.putString("orders", str262);
    xmlPut.putString("mergedCase", str263);
    xmlPut.rise();
    xmlPut.descend("event5");
    xmlPut.putString("date", str264);
    xmlPut.putString("event", str265);
    xmlPut.putString("party1present", str266);
    xmlPut.putString("party1sworn", str267);
    xmlPut.putString("party1atty", str268);
    xmlPut.putString("party2present", str269);
    xmlPut.putString("party2sworn", str270);
    xmlPut.putString("party2atty", str271);
    xmlPut.putString("orders", str272);
    xmlPut.putString("mergedCase", str273);
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.descend("casenotes");
    xmlPut.descend("user1");
    xmlPut.putString("userid", str274);
    xmlPut.putString("userrole", str275);
    xmlPut.putString("lastdate", str276);
    xmlPut.putString("publicnotes", str277);
    xmlPut.putString("privatenotes", "");
    xmlPut.rise();
    xmlPut.descend("user2");
    xmlPut.putString("userid", str278);
    xmlPut.putString("userrole", str279);
    xmlPut.putString("lastdate", str280);
    xmlPut.putString("publicnotes", str281);
    xmlPut.putString("privatenotes", "");
    xmlPut.rise();
    xmlPut.descend("user3");
    xmlPut.putString("userid", str282);
    xmlPut.putString("userrole", str283);
    xmlPut.putString("lastdate", str284);
    xmlPut.putString("publicnotes", str285);
    xmlPut.putString("privatenotes", "");
    xmlPut.rise();
    xmlPut.descend("user4");
    xmlPut.putString("userid", str286);
    xmlPut.putString("userrole", str287);
    xmlPut.putString("lastdate", str288);
    xmlPut.putString("publicnotes", str289);
    xmlPut.putString("privatenotes", "");
    xmlPut.rise();
    xmlPut.rise();
    xmlPut.rise();
// write xml
    xmlPut.save("/users/jamesreid/cases/tempsave.xml");
}


//CASE STATUS TAB FUNCTIONS
void MainWindow::on_toolButton_CaseClear_clicked()
{
    ui->lineEdit_p1Findfname->clear();
    ui->lineEdit_p1Findmname->clear();
    ui->lineEdit_p1Findlname->clear();
    ui->lineEdit_p2Findfname->clear();
    ui->lineEdit_p2Findmname->clear();
    ui->lineEdit_p2Findlname->clear();
    ui->lineEdit_findCaseNumber->clear();
    ui->lineEdit_findCCPORID->clear();
    ui->lineEdit_findCaseNumber->clear();
    ui->comboBox_findClerk->setCurrentIndex(0);
    ui->comboBox_findCCPORStatus->setCurrentIndex(0);
}





//CASE RECORD TAB FUNCTIONS
void MainWindow::on_toolButton_caseSave_clicked()
{  
    SaveCaseRecord();
    QString caseId;
    caseId = ui->listWidget_listCaseRecord->currentItem()->text();
    casesave nCaseSave;
    nCaseSave.setModal(true);
    nCaseSave.setCase(caseId);
    nCaseSave.exec();
}
void MainWindow::on_toolButton_caseRecordNew_clicked()
{
    newCase nCase;
    nCase.setModal(true);
    nCase.exec();
}
//DOCKET TAB FUNCTIONS
void MainWindow::on_toolButton_caseReissueDocket_clicked()
{
    Reissue nReissue;
    nReissue.setModal(true);
    nReissue.exec();
}
void MainWindow::on_toolButton_unscheduleCase_clicked()
{
   QString caseNumber;
   caseNumber = ui->listWidget_caseDocket->currentItem()->text();
   removedocket nRemoveDocket;
   nRemoveDocket.setModal(true);
   nRemoveDocket.setData(caseNumber);
   nRemoveDocket.exec();
}
void MainWindow::on_toolButton_CaseAddDocket_clicked()
{
    QString caseId;
    caseId = ui->listWidget_caseDocket->currentItem()->text();
    adddocket nAddCase;
    nAddCase.setModal(true);
    nAddCase.setCaseAdd(caseId);
    nAddCase.exec();
}
void MainWindow::on_toolButton_caseExport_clicked()
{
    Export nExport;
    nExport.setModal(true);
    nExport.exec();
}
//COURT ORDERS FUNCTIONS
void MainWindow::on_toolButton_saveOrders_clicked()
{
    QString orderId;
    orderId = ui->listWidget_caseOrderList->currentItem()->text();
    ordersave nOrderSave;
    nOrderSave.setModal(true);
    nOrderSave.setOrderId(orderId);
    nOrderSave.exec();
}

void MainWindow::on_toolButton_caseDrop_clicked()
{
    Confirm nDrop;
    nDrop.setModal(true);
    nDrop.exec();
}
void MainWindow::on_toolButton_CaseMerge_clicked()
{
    Consolidate nMerge;
    nMerge.setModal(true);
    nMerge.exec();
}
void MainWindow::on_toolButton_caseReissueOrder_clicked()
{
    Reissue nReissue;
    nReissue.setModal(true);
    nReissue.exec();
}
void MainWindow::on_toolButton_CaseSeperate_clicked()
{
    seperate nSeperate;
    nSeperate.setModal(true);
    nSeperate.exec();
}

void MainWindow::on_toolButton_caseContinuance_clicked()
{
    Continuance nContinuance;
    nContinuance.setModal(true);
    nContinuance.exec();
}

void MainWindow::on_toolButton_caseStatus_clicked()
{
    casestatus nCasestatus;
    nCasestatus.setModal(true);
    nCasestatus.exec();
}

void MainWindow::on_toolButton_addCaseMerge_clicked()
{
    addrelatedcase nAddRelatedCase;
    nAddRelatedCase.setModal(true);
    nAddRelatedCase.exec();
}

void MainWindow::on_toolButton_generateOrders_clicked()
{
    QString orderId;
    orderId = ui->listWidget_caseOrderList->currentItem()->text();
    generateOrders nGenerateOrders;
    nGenerateOrders.setModal(true);
    nGenerateOrders.SetOrderID(orderId);
    nGenerateOrders.exec();
}

void MainWindow::on_toolButton_caseRenew_clicked()
{
    renewCase nRenewCase;
    nRenewCase.setModal(true);
    nRenewCase.exec();
}
void MainWindow::on_toolButton_AddParties_clicked()
{
    addparties nAddparties;
    nAddparties.setModal(true);
    nAddparties.exec();
}

//COURT STAFF FUNCTIONS
void MainWindow::on_toolButton_staffUpdate_clicked()
{
    userupdate nAddUser;
    nAddUser.setModal(true);
    nAddUser.exec();
}


//SET UP CONFIGURATION TABLES
void MainWindow::AddCourtLocations(QString cname, QString cdivision, QString cstreet, QString cmailing, QString locationid)
{
    QTreeWidgetItem *cfg = new QTreeWidgetItem(ui->treeWidget_Locations);
    cfg->setText(0,cname);
    cfg->setText(1,cdivision);
    cfg->setText(2,cstreet);
    cfg->setText(3,cmailing);
    cfg->setText(4,locationid);
    ui->treeWidget_Locations->addTopLevelItem(cfg);
}
void MainWindow::AddCourtCourtrooms(QString clocation, QString cname, QString cjudge)
{
    QTreeWidgetItem *cfg1 = new QTreeWidgetItem(ui->treeWidget_Courtrooms);
    cfg1->setText(0,clocation);
    cfg1->setText(1,cname);
    cfg1->setText(2,cjudge);
    ui->treeWidget_Courtrooms->addTopLevelItem(cfg1);
}
void MainWindow::AddCourtDepartments(QString dname, QString droom, QString dofficer, QString dreporter)
{
    QTreeWidgetItem *cfg2 = new QTreeWidgetItem(ui->treeWidget_Departments);
    cfg2->setText(0,dname);
    cfg2->setText(1,droom);
    cfg2->setText(2,dofficer);
    cfg2->setText(3,dreporter);
    ui->treeWidget_Departments->addTopLevelItem(cfg2);
}
void MainWindow::AddCourtAgencies(QString aname, QString aori)
{
    QTreeWidgetItem *cfg3 = new QTreeWidgetItem(ui->treeWidget_Agencies);
    cfg3->setText(0,aname);
    cfg3->setText(1,aori);
    ui->treeWidget_Agencies->addTopLevelItem(cfg3);
}

//FACCTS SECURITY CONFIG
void MainWindow::LoadSecurity()
{
QXmlGet xmlGet;
xmlGet.load("/Users/jamesreid/faccts_cng/faccts_user.xml");
xmlGet.find("faccts");
xmlGet.findAndDescend("userconfiguration");
xmlGet.findAndDescend("administration");
xmlGet.find("casestatusview");
bool casestatusview = xmlGet.getBool();
xmlGet.find("casestatusexport");
bool casestatusexport = xmlGet.getBool();
xmlGet.find("casestatusimport");
bool casestatusimport = xmlGet.getBool();
xmlGet.find("caserecordview");
bool caserecordview = xmlGet.getBool();
xmlGet.find("caserecordedit");
bool caserecordedit = xmlGet.getBool();
xmlGet.find("casedocketview");
bool casedocketview = xmlGet.getBool();
xmlGet.find("casedocketschedule");
bool casedocketschedule = xmlGet.getBool();
xmlGet.find("courtorderview");
bool courtorderview = xmlGet.getBool();
xmlGet.find("courtorderedit");
bool courtorderedit = xmlGet.getBool();
xmlGet.find("courtorderunsign");
bool courtorderunsign = xmlGet.getBool();
xmlGet.find("adminuser");
bool adminuser = xmlGet.getBool();
xmlGet.find("admincourt");
bool admincourt = xmlGet.getBool();
xmlGet.rise();
xmlGet.findAndDescend("judicialofficer");
xmlGet.find("casestatusview");
bool casestatusview2 = xmlGet.getBool();
xmlGet.find("casestatusexport");
bool casestatusexport2 = xmlGet.getBool();
xmlGet.find("casestatusimport");
bool casestatusimport2 = xmlGet.getBool();
xmlGet.find("caserecordview");
bool caserecordview2 = xmlGet.getBool();
xmlGet.find("caserecordedit");
bool caserecordedit2 = xmlGet.getBool();
xmlGet.find("casedocketview");
bool casedocketview2 = xmlGet.getBool();
xmlGet.find("casedocketschedule");
bool casedocketschedule2 = xmlGet.getBool();
xmlGet.find("courtorderview");
bool courtorderview2 = xmlGet.getBool();
xmlGet.find("courtorderedit");
bool courtorderedit2 = xmlGet.getBool();
xmlGet.find("courtorderunsign");
bool courtorderunsign2 = xmlGet.getBool();
xmlGet.rise();
xmlGet.findAndDescend("courtclerk");
xmlGet.find("casestatusview");
bool casestatusview3 = xmlGet.getBool();
xmlGet.find("casestatusexport");
bool casestatusexport3 = xmlGet.getBool();
xmlGet.find("casestatusimport");
bool casestatusimport3 = xmlGet.getBool();
xmlGet.find("caserecordview");
bool caserecordview3 = xmlGet.getBool();
xmlGet.find("caserecordedit");
bool caserecordedit3 = xmlGet.getBool();
xmlGet.find("casedocketview");
bool casedocketview3 = xmlGet.getBool();
xmlGet.find("casedocketschedule");
bool casedocketschedule3 = xmlGet.getBool();
xmlGet.find("courtorderview");
bool courtorderview3 = xmlGet.getBool();
xmlGet.find("courtorderedit");
bool courtorderedit3 = xmlGet.getBool();
xmlGet.find("courtorderunsign");
bool courtorderunsign3 = xmlGet.getBool();
xmlGet.rise();
xmlGet.findAndDescend("familycourt");
xmlGet.find("casestatusview");
bool casestatusview4 = xmlGet.getBool();
xmlGet.find("casestatusexport");
bool casestatusexport4 = xmlGet.getBool();
xmlGet.find("casestatusimport");
bool casestatusimport4 = xmlGet.getBool();
xmlGet.find("caserecordview");
bool caserecordview4 = xmlGet.getBool();
xmlGet.find("caserecordedit");
bool caserecordedit4 = xmlGet.getBool();
xmlGet.find("casedocketview");
bool casedocketview4 = xmlGet.getBool();
xmlGet.find("casedocketschedule");
bool casedocketschedule4 = xmlGet.getBool();
xmlGet.rise();
xmlGet.findAndDescend("selfhelp");
xmlGet.find("casestatusview");
bool casestatusview5 = xmlGet.getBool();
xmlGet.find("casestatusexport");
bool casestatusexport5 = xmlGet.getBool();
xmlGet.find("casestatusimport");
bool casestatusimport5 = xmlGet.getBool();
xmlGet.find("caserecordview");
bool caserecordview5 = xmlGet.getBool();
xmlGet.find("caserecordedit");
bool caserecordedit5 = xmlGet.getBool();
xmlGet.find("casedocketview");
bool casedocketview5 = xmlGet.getBool();
xmlGet.rise();
xmlGet.findAndDescend("businessoffice");
xmlGet.find("casestatusview");
bool casestatusview6 = xmlGet.getBool();
xmlGet.find("caserecordview");
bool caserecordview6 = xmlGet.getBool();
xmlGet.find("caserecordedit");
bool caserecordedit6 = xmlGet.getBool();
xmlGet.rise();
xmlGet.rise();

ui->checkBox_caseStatusView->setChecked(casestatusview);
ui->checkBox_caseStatusExport->setChecked(casestatusexport);
ui->checkBox_caseStatusImport->setChecked(casestatusimport);
ui->checkBox_caseRecordView->setChecked(caserecordview);
ui->checkBox_caseRecordEdit->setChecked(caserecordedit);
ui->checkBox_caseDocketView->setChecked(casedocketview);
ui->checkBox_caseDocketSchedule->setChecked(casedocketschedule);
ui->checkBox_courtOrdersView->setChecked(courtorderview);
ui->checkBox_courtOrdersEdit->setChecked(courtorderedit);
ui->checkBox_courtOrdersUnsign->setChecked(courtorderunsign);
ui->checkBox_adminUserSet->setChecked(adminuser);
ui->checkBox_adminCourtSet->setChecked(admincourt);

ui->checkBox_caseStatusView_2->setChecked(casestatusview2);
ui->checkBox_caseStatusExport_2->setChecked(casestatusexport2);
ui->checkBox_caseStatusImport_2->setChecked(casestatusimport2);
ui->checkBox_caseRecordView_2->setChecked(caserecordview2);
ui->checkBox_caseRecordEdit_2->setChecked(caserecordedit2);
ui->checkBox_caseDocketView_2->setChecked(casedocketview2);
ui->checkBox_caseDocketEdit_2->setChecked(casedocketschedule2);
ui->checkBox_courtOrdersView_2->setChecked(courtorderview2);
ui->checkBox_courtOrdersEdit_2->setChecked(courtorderedit2);
ui->checkBox_courtOrdersUnsign_2->setChecked(courtorderunsign2);

ui->checkBox_caseStatusView_3->setChecked(casestatusview3);
ui->checkBox_caseStatusExport_3->setChecked(casestatusexport3);
ui->checkBox_caseStatusImport_3->setChecked(casestatusimport3);
ui->checkBox_caseRecordView_3->setChecked(caserecordview3);
ui->checkBox_caseRecordEdit_3->setChecked(caserecordedit3);
ui->checkBox_caseDocketView_3->setChecked(casedocketview3);
ui->checkBox_caseDocketEdit_3->setChecked(casedocketschedule3);
ui->checkBox_courtOrdersView_3->setChecked(courtorderview3);
ui->checkBox_courtOrdersEdit_3->setChecked(courtorderedit3);
ui->checkBox_courtOrdersUnsign_3->setChecked(courtorderunsign3);

ui->checkBox_caseStatusView_4->setChecked(casestatusview4);
ui->checkBox_caseStatusExport_4->setChecked(casestatusexport4);
ui->checkBox_caseStatusImport_4->setChecked(casestatusimport4);
ui->checkBox_caseRecordView_4->setChecked(caserecordview4);
ui->checkBox_caseRecordEdit_4->setChecked(caserecordedit4);
ui->checkBox_caseDocketView_4->setChecked(casedocketview4);
ui->checkBox_caseDocketEdit_4->setChecked(casedocketschedule4);

ui->checkBox_caseStatusView_5->setChecked(casestatusview5);
ui->checkBox_caseStatusExport_5->setChecked(casestatusexport5);
ui->checkBox_caseStatusImport_5->setChecked(casestatusimport5);
ui->checkBox_caseRecordView_5->setChecked(caserecordview5);
ui->checkBox_caseRecordEdit_5->setChecked(caserecordedit5);
ui->checkBox_caseDocketView_5->setChecked(casedocketview5);

ui->checkBox_caseStatusView_6->setChecked(casestatusview6);
ui->checkBox_caseRecordView_6->setChecked(caserecordview6);
ui->checkBox_caseRecordEdit_6->setChecked(caserecordedit6);

ui->checkBox_caseStatusView_10->setChecked(casestatusview);
ui->checkBox_caseStatusExport_10->setChecked(casestatusexport);
ui->checkBox_caseStatusImport_10->setChecked(casestatusimport);
ui->checkBox_caseRecordView_10->setChecked(caserecordview);
ui->checkBox_caseRecordEdit_10->setChecked(caserecordedit);
ui->checkBox_caseDocketView_10->setChecked(casedocketview);
ui->checkBox_caseDocketEdit_10->setChecked(casedocketschedule);
ui->checkBox_courtOrdersView_10->setChecked(courtorderview);
ui->checkBox_courtOrdersEdit_10->setChecked(courtorderedit);
ui->checkBox_courtOrdersUnsign_10->setChecked(courtorderunsign);
ui->checkBox_adminUserSet_10->setChecked(adminuser);
ui->checkBox_adminCourtSet_10->setChecked(admincourt);

ui->checkBox_caseStatusView_11->setChecked(casestatusview2);
ui->checkBox_caseStatusExport_11->setChecked(casestatusexport2);
ui->checkBox_caseStatusImport_11->setChecked(casestatusimport2);
ui->checkBox_caseRecordView_11->setChecked(caserecordview2);
ui->checkBox_caseRecordEdit_11->setChecked(caserecordedit2);
ui->checkBox_caseDocketView_11->setChecked(casedocketview2);
ui->checkBox_caseDocketEdit_11->setChecked(casedocketschedule2);
ui->checkBox_courtOrdersView_11->setChecked(courtorderview2);
ui->checkBox_courtOrdersEdit_11->setChecked(courtorderedit2);
ui->checkBox_courtOrdersUnsign_11->setChecked(courtorderunsign2);

ui->checkBox_caseStatusView_12->setChecked(casestatusview3);
ui->checkBox_caseStatusExport_12->setChecked(casestatusexport3);
ui->checkBox_caseStatusImport_12->setChecked(casestatusimport3);
ui->checkBox_caseRecordView_12->setChecked(caserecordview3);
ui->checkBox_caseRecordEdit_12->setChecked(caserecordedit3);
ui->checkBox_caseDocketView_12->setChecked(casedocketview3);
ui->checkBox_caseDocketEdit_12->setChecked(casedocketschedule3);
ui->checkBox_courtOrdersView_12->setChecked(courtorderview3);
ui->checkBox_courtOrdersEdit_12->setChecked(courtorderedit3);
ui->checkBox_courtOrdersUnsign_12->setChecked(courtorderunsign3);

ui->checkBox_caseStatusView_13->setChecked(casestatusview4);
ui->checkBox_caseStatusExport_13->setChecked(casestatusexport4);
ui->checkBox_caseStatusImport_13->setChecked(casestatusimport4);
ui->checkBox_caseRecordView_13->setChecked(caserecordview4);
ui->checkBox_caseRecordEdit_13->setChecked(caserecordedit4);
ui->checkBox_caseDocketView_13->setChecked(casedocketview4);
ui->checkBox_caseDocketEdit_13->setChecked(casedocketschedule4);

ui->checkBox_caseStatusView_14->setChecked(casestatusview5);
ui->checkBox_caseStatusExport_14->setChecked(casestatusexport5);
ui->checkBox_caseStatusImport_14->setChecked(casestatusimport5);
ui->checkBox_caseRecordView_14->setChecked(caserecordview5);
ui->checkBox_caseRecordEdit_14->setChecked(caserecordedit5);
ui->checkBox_caseDocketView_14->setChecked(casedocketview5);

ui->checkBox_caseStatusView_15->setChecked(casestatusview6);
ui->checkBox_caseRecordView_15->setChecked(caserecordview6);
ui->checkBox_caseRecordEdit_15->setChecked(caserecordedit6);
}

// DEMO CODE ONLY FACCTS USER INFO -
// REPLACED WITH READ USER INT
void MainWindow::LoadUserSet()
{
    QString usr1;
    QString usr2;
    QString usr3;
    QString usr4;
    QString usr5;
    QString usr6;
    QString usr7;
    QString usr8;
    QString usr9;
    QString usr10;
    QString usr11;
    QString usr12;
    QString usr13;
    QString usr14;
    QString usr15;
    QString usr16;
    QString usr17;
    QString usr18;
    QString usr19;
    QString usr20;
    QString usr21;
    QString usr22;
    QString usr23;
    QString usr24;
    QString usr25;
    QString usr26;
    QString usr27;
    QString usr28;

    QString img1;
    QString img2;
    QString img3;
    QString img4;
    QString img5;
    QString img6;
    QString img7;
    QString img8;
    QString img9;
    QString img10;

    QString addusr1;
    QString addusr2;
    QString addusr3;
    QString addusr4;
    QString addusr5;
    QString addusr6;

    int ua, ub, uc, ud, ue, uf, ug, uh;

    QXmlGet xmlGet;
    xmlGet.load("/Users/jamesreid/faccts_cng/faccts_user.xml");
    xmlGet.find("faccts");
    xmlGet.find("userset");
    xmlGet.descend();
    xmlGet.findAndDescend("user1");
    xmlGet.find("userid");
    usr1 = xmlGet.getString();
    xmlGet.find("firstname");
    usr2 = xmlGet.getString();
    xmlGet.find("middlename");
    usr3 = xmlGet.getString();
    xmlGet.find("lastname");
    usr4 = xmlGet.getString();
    xmlGet.find("createdate");
    usr5 = xmlGet.getString();
    xmlGet.find("userlogin");
    bool active1 = xmlGet.getBool();
    xmlGet.find("userrole");
    ua = xmlGet.getInt();
    xmlGet.find("substitute");
    ub = xmlGet.getInt();
    xmlGet.find("userphone");
    usr6 = xmlGet.getString();
    xmlGet.find("useremail");
    usr7 = xmlGet.getString();
    xmlGet.find("userclets");
    bool userclets = xmlGet.getBool();
    xmlGet.find("userimage");
    img1 = xmlGet.getString();
    xmlGet.find("sealimage");
    img2 = xmlGet.getString();
    xmlGet.find("useravailable");
    bool useravailable = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("user2");;
    xmlGet.find("userid");
    usr8 = xmlGet.getString();
    xmlGet.find("firstname");
    usr9 = xmlGet.getString();
    xmlGet.find("middlename");
    usr10 = xmlGet.getString();
    xmlGet.find("lastname");
    usr11 = xmlGet.getString();
    xmlGet.find("createdate");
    usr12 = xmlGet.getString();
    xmlGet.find("userlogin");
    bool active2 = xmlGet.getBool();
    xmlGet.find("userrole");
    uc = xmlGet.getInt();
    xmlGet.find("substitute");
    ud = xmlGet.getInt();
    xmlGet.find("userphone");
    usr13 = xmlGet.getString();
    xmlGet.find("useremail");
    usr14 = xmlGet.getString();
    xmlGet.find("userclets");
    bool userclets2 = xmlGet.getBool();
    xmlGet.find("userimage");
    img3 = xmlGet.getString();
    xmlGet.find("sealimage");
    img4 = xmlGet.getString();
    xmlGet.find("useravailable");
    bool useravailable2 = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("user3");
    xmlGet.find("userid");
    usr15 = xmlGet.getString();
    xmlGet.find("firstname");
    usr16 = xmlGet.getString();
    xmlGet.find("middlename");
    usr17 = xmlGet.getString();
    xmlGet.find("lastname");
    usr18 = xmlGet.getString();
    xmlGet.find("createdate");
    usr19 = xmlGet.getString();
    xmlGet.find("userlogin");
    bool active3 = xmlGet.getBool();
    xmlGet.find("userrole");
    ue = xmlGet.getInt();
    xmlGet.find("substitute");
    uf = xmlGet.getInt();
    xmlGet.find("userphone");
    usr20 = xmlGet.getString();
    xmlGet.find("useremail");
    usr21 = xmlGet.getString();
    xmlGet.find("userclets");
    bool userclets3 = xmlGet.getBool();
    xmlGet.find("userimage");
    img5 = xmlGet.getString();
    xmlGet.find("sealimage");
    img6 = xmlGet.getString();
    xmlGet.find("useravailable");
    bool useravailable3 = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("user4");
    xmlGet.find("userid");
    usr22 = xmlGet.getString();
    xmlGet.find("firstname");
    usr23 = xmlGet.getString();
    xmlGet.find("middlename");
    usr24 = xmlGet.getString();
    xmlGet.find("lastname");
    usr25 = xmlGet.getString();
    xmlGet.find("createdate");
    usr26 = xmlGet.getString();
    xmlGet.find("userlogin");
    bool active4 = xmlGet.getBool();
    xmlGet.find("userrole");
    ug = xmlGet.getInt();
    xmlGet.find("substitute");
    uh = xmlGet.getInt();
    xmlGet.find("userphone");
    usr27 = xmlGet.getString();
    xmlGet.find("useremail");
    usr28 = xmlGet.getString();
    xmlGet.find("userclets");
    bool userclets4 = xmlGet.getBool();
    xmlGet.find("userimage");
    img7 = xmlGet.getString();
    xmlGet.find("sealimage");
    img8 = xmlGet.getString();
    xmlGet.find("useravailable");
    bool useravailable4 = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("user5");
    xmlGet.find("userid");
    addusr1 = xmlGet.getString();
    xmlGet.find("firstname");
    addusr2 = xmlGet.getString();
    xmlGet.find("middlename");
    addusr3 = xmlGet.getString();
    xmlGet.find("lastname");
    addusr4 = xmlGet.getString();
    xmlGet.find("createdate");
    addusr5 = xmlGet.getString();
    xmlGet.find("useremail");
    addusr6 = xmlGet.getString();
    xmlGet.find("userclets");
    bool userclets5 = xmlGet.getBool();
    xmlGet.find("userimage");
    img9 = xmlGet.getString();
    xmlGet.find("sealimage");
    img10 = xmlGet.getString();

    ui->lineEdit_user1UserID->setText(usr1);
    ui->lineEdit_user1FirstName->setText(usr2);
    ui->lineEdit_user1MiddleName->setText(usr3);
    ui->lineEdit_user1LastName->setText(usr4);
    ui->lineEdit_user1CreateDate->setText(usr5);
    ui->comboBox_user1Role->setCurrentIndex(ua);
    ui->comboBox_user1SubRole->setCurrentIndex(ua);
    ui->lineEdit_user1Phone->setText(usr6);
    ui->lineEdit_user1Email->setText(usr7);
    ui->checkBox_user1CLETS->setChecked(userclets);
    ui->checkBox_user1CletsSet->setChecked(userclets);
    ui->checkBox_user1Available->setChecked(useravailable);
    ui->lineEdit_user1FullName->setText(usr1);
    ui->checkBox_user1Activated->setChecked(active1);
    ui->listWidget_user1->addItem(usr1);
    ui->listWidget_user1->addItem(usr22);
    ui->listWidget_user1->setCurrentRow(ub);

//PULL IMAGES AND SETSTYLE SHEET ON FRAMES Qt REQUIRES SET STYLE FOR IMAGE SET
    QStringList userimage1;
    userimage1 << "background:black;background-position: center; background-image: url(" << img1 << ");background-repeat: no-repeat;";
    QString imgfile1 = userimage1.join("");
    ui->frame_staffPicture_1->setStyleSheet(imgfile1);

    QStringList sealimage1;
    sealimage1 << "background:black;background-position: center; background-image: url(" << img2 << ");background-repeat: no-repeat;";
    QString imgfile2 = sealimage1.join("");
    ui->frame_sealImage_1->setStyleSheet(imgfile2);
//

    ui->lineEdit_user2UserID->setText(usr8);
    ui->lineEdit_user2FirstName->setText(usr9);
    ui->lineEdit_user2MiddleName->setText(usr10);
    ui->lineEdit_user2LastName->setText(usr11);
    ui->lineEdit_user2CreateDate->setText(usr12);
    ui->comboBox_user2Role->setCurrentIndex(uc);
    ui->comboBox_user2SubRole->setCurrentIndex(uc);
    ui->lineEdit_user2Phone->setText(usr13);
    ui->lineEdit_user2Email->setText(usr14);
    ui->checkBox_user2CLETS->setChecked(userclets2);
    ui->checkBox_user2CletsSet->setChecked(userclets2);
    ui->checkBox_user2Available->setChecked(useravailable2);
    ui->lineEdit_user2FullName->setText(usr8);
    ui->checkBox_user2Activated->setChecked(active2);
    ui->listWidget_user2->addItem(usr8);
    ui->listWidget_user2->addItem(usr15);
    ui->listWidget_user2->setCurrentRow(ud);

//PULL IMAGES AND SETSTYLE SHEET ON FRAMES Qt REQUIRES SET STYLE FOR IMAGE SET
    QStringList userimage2;
    userimage2 << "background:black;background-position: center; background-image: url(" << img3 << ");background-repeat: no-repeat;";
    QString imgfile3 = userimage2.join("");
    ui->frame_staffPicture_2->setStyleSheet(imgfile3);

    QStringList sealimage2;
    sealimage2 << "background:black;background-position: center; background-image: url(" << img4 << ");background-repeat: no-repeat;";
    QString imgfile4 = sealimage2.join("");
    ui->frame_sealImage_2->setStyleSheet(imgfile4);
//
    ui->lineEdit_user3UserID->setText(usr15);
    ui->lineEdit_user3FirstName->setText(usr16);
    ui->lineEdit_user3MiddleName->setText(usr17);
    ui->lineEdit_user3LastName->setText(usr18);
    ui->lineEdit_user3CreateDate->setText(usr19);
    ui->comboBox_user3Role->setCurrentIndex(ue);
    ui->comboBox_user3SubRole->setCurrentIndex(ue);
    ui->lineEdit_user3Phone->setText(usr20);
    ui->lineEdit_user3Email->setText(usr21);
    ui->checkBox_user3CLETS->setChecked(userclets3);
    ui->checkBox_user3CletsSet->setChecked(userclets3);
    ui->checkBox_user3Available->setChecked(useravailable3);
    ui->lineEdit_user3FullName->setText(usr15);
    ui->checkBox_user3Activated->setChecked(active3);
    ui->listWidget_user3->addItem(usr8);
    ui->listWidget_user3->addItem(usr15);
    ui->listWidget_user3->setCurrentRow(uf);

//PULL IMAGES AND SETSTYLE SHEET ON FRAMES Qt REQUIRES SET STYLE FOR IMAGE SET
    QStringList userimage3;
    userimage3 << "background:black;background-position: center; background-image: url(" << img5 << ");background-repeat: no-repeat;";
    QString imgfile5 = userimage3.join("");
    ui->frame_staffPicture_3->setStyleSheet(imgfile5);

    QStringList sealimage3;
    sealimage3 << "background:black;background-position: center; background-image: url(" << img6 << ");background-repeat: no-repeat;";
    QString imgfile6 = sealimage3.join("");
    ui->frame_sealImage_3->setStyleSheet(imgfile6);
//

    ui->lineEdit_user4UserID->setText(usr22);
    ui->lineEdit_user4FirstName->setText(usr23);
    ui->lineEdit_user4MiddleName->setText(usr24);
    ui->lineEdit_user4LastName->setText(usr25);
    ui->lineEdit_user4CreateDate->setText(usr26);
    ui->comboBox_user4Role->setCurrentIndex(ug);
    ui->comboBox_user1SubRole->setCurrentIndex(ug);
    ui->lineEdit_user4Phone->setText(usr27);
    ui->lineEdit_user4Email->setText(usr28);
    ui->checkBox_user4CLETS->setChecked(userclets4);
    ui->checkBox_user4CletsSet->setChecked(userclets2);
    ui->checkBox_user4Available->setChecked(useravailable4);
    ui->lineEdit_user4FullName->setText(usr22);
    ui->checkBox_user4Activated->setChecked(active4);
    ui->listWidget_user4->addItem(usr1);
    ui->listWidget_user4->addItem(usr22);
    ui->listWidget_user4->setCurrentRow(uh);
    ui->listWidget_userList->addItem(addusr1);

//PULL IMAGES AND SETSTYLE SHEET ON FRAMES Qt REQUIRES SET STYLE FOR IMAGE SET
    QStringList userimage4;
    userimage4 << "background:black;background-position: center; background-image: url(" << img7 << ");background-repeat: no-repeat;";
    QString imgfile7 = userimage4.join("");
    ui->frame_staffPicture_4->setStyleSheet(imgfile7);

    QStringList sealimage4;
    sealimage4 << "background:black;background-position: center; background-image: url(" << img8 << ");background-repeat: no-repeat;";
    QString imgfile8 = sealimage4.join("");
    ui->frame_sealImage_4->setStyleSheet(imgfile8);
//

    ui->lineEdit_user5UserID->setText(addusr1);
    ui->lineEdit_user5FirstName->setText(addusr2);
    ui->lineEdit_user5MiddleName->setText(addusr3);
    ui->lineEdit_user5LastName->setText(addusr4);
    ui->lineEdit_user5CreateDate->setText(addusr5);
    ui->lineEdit_user5Email->setText(addusr6);
    ui->lineEdit_user5FullName->setText(addusr1);
    ui->checkBox_user5CLETS->setChecked(userclets5);

//PULL IMAGES AND SETSTYLE SHEET ON FRAMES Qt REQUIRES SET STYLE FOR IMAGE SET
    QStringList userimage5;
    userimage5 << "background:black;background-position: center; background-image: url(" << img9 << ");background-repeat: no-repeat;";
    QString imgfile9 = userimage5.join("");
    ui->frame_staffPicture_5->setStyleSheet(imgfile9);

    QStringList sealimage5;
    sealimage5 << "background:black;background-position: center; background-image: url(" << img10 << ");background-repeat: no-repeat;";
    QString imgfile10 = sealimage5.join("");
    ui->frame_sealImage_5->setStyleSheet(imgfile10);
//

//ADD CLERKS TO THE FIND DROPDOWN ON CASE STATUS MENU
    ui->comboBox_findClerk->addItem(usr1);
    ui->comboBox_findClerk->addItem(usr8);
    ui->comboBox_findClerk->addItem(usr15);
    ui->comboBox_findClerk->addItem(usr22);
    ui->comboBox_findClerk->addItem(addusr1);
}

// READ FACCTS COURT CONFIG
void MainWindow::LoadConfiguration()
{
    QString cfg1;
    QString cfg2;
    QString cfg3;
    QString cfg4;
    QString cfg5;
    QString cfg6;
    QString cfg7;
    QString cfg8;
    QString cfg9;
    QString cfg10;
    QString cfg11;
    QString cfg12;
    QString cfg13;
    QString cfg14;
    QString cfg15;
    QString cfg16;
    QString cfg17;
    QString cfg18;
    QString cfg19;
    QString cfg20;
    QString cfg21;
    QString cfg22;
    QString cfg23;
    QString cfg24;
    QString cfg25;
    QString cfg26;
    QString cfg27;
    QString cfg28;
    QString cfg29;
    QString cfg30;
    QString cfg31;
    QString cfg32;
    QString cfg33;
    QString cfg34;
    QString cfg35;
    QString cfg36;
    QString cfg37;
    QString cfg38;
    QString cfg39;
    QString cfg40;
    QString cfg41;
    QString cfg42;
    QString cfg43;
    QString cfg44;
    QString cfg45;
    QString cfg46;
    QString cfg47;
    QString cfg48;
    QString cfg49;
    QString cfg50;
    QString cfg51;
    QString cfg52;
    QString cfg53;
    QString importschedule;
    QString exportschedule;

    int ca, cb, cc;

    QXmlGet xmlGet;
    xmlGet.load("/Users/jamesreid/faccts_cng/faccts_config.xml");
    xmlGet.findAndDescend("faccts");
    xmlGet.findAndDescend("court");
    xmlGet.find("county");
    ca = xmlGet.getInt();
    xmlGet.find("primarycourtid");
    cfg1 = xmlGet.getString();
    xmlGet.find("issuingstate");
    cfg2 = xmlGet.getString();
    xmlGet.find("judge");
    cfg3 = xmlGet.getString();
    xmlGet.find("ceo");
    cfg4 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("locations");
    xmlGet.findAndDescend("location1");
    xmlGet.find("courtname");
    cfg5 = xmlGet.getString();
    xmlGet.find("division");
    cfg6 = xmlGet.getString();
    xmlGet.find("streetaddress");
    cfg7 = xmlGet.getString();
    xmlGet.find("mailingaddress");
    cfg8 = xmlGet.getString();
    xmlGet.find("courtlocationID");
    cfg9 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("location2");
    xmlGet.find("courtname");
    cfg10 = xmlGet.getString();
    xmlGet.find("division");
    cfg11 = xmlGet.getString();
    xmlGet.find("streetaddress");
    cfg12 = xmlGet.getString();
    xmlGet.find("mailingaddress");
    cfg13 = xmlGet.getString();
    xmlGet.find("courtlocationID");
    cfg14 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("courtrooms");
    xmlGet.findAndDescend("courtroom1");
    xmlGet.find("location");
    cfg15 = xmlGet.getString();
    xmlGet.find("courtroomname");
    cfg16 = xmlGet.getString();
    xmlGet.find("judge");
    cfg17 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("courtroom2");
    xmlGet.find("location");
    cfg18 = xmlGet.getString();
    xmlGet.find("courtroomname");
    cfg19 = xmlGet.getString();
    xmlGet.find("judge");
    cfg20 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("courtroom3");
    xmlGet.find("location");
    cfg21 = xmlGet.getString();
    xmlGet.find("courtroomname");
    cfg22 = xmlGet.getString();
    xmlGet.find("judge");
    cfg23 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("courtroom4");
    xmlGet.find("location");
    cfg24 = xmlGet.getString();
    xmlGet.find("courtroomname");
    cfg25 = xmlGet.getString();
    xmlGet.find("judge");
    cfg26 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("departments");
    xmlGet.findAndDescend("department1");
    xmlGet.find("departmentname");
    cfg27 = xmlGet.getString();
    xmlGet.find("room");
    cfg28 = xmlGet.getString();
    xmlGet.find("branchofficer");
    cfg29 = xmlGet.getString();
    xmlGet.find("reporter");
    cfg30 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("department2");
    xmlGet.find("departmentname");
    cfg31 = xmlGet.getString();
    xmlGet.find("room");
    cfg32 = xmlGet.getString();
    xmlGet.find("branchofficer");
    cfg33 = xmlGet.getString();
    xmlGet.find("reporter");
    cfg34 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("department3");
    xmlGet.find("departmentname");
    cfg35 = xmlGet.getString();
    xmlGet.find("room");
    cfg36 = xmlGet.getString();
    xmlGet.find("branchofficer");
    cfg37 = xmlGet.getString();
    xmlGet.find("reporter");
    cfg38 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("agencyori");
    xmlGet.findAndDescend("agency1");
    xmlGet.find("agencyname");
    cfg39 = xmlGet.getString();
    xmlGet.find("ori");
    cfg40 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("agency2");
    xmlGet.find("agencyname");
    cfg41 = xmlGet.getString();
    xmlGet.find("ori");
    cfg42 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("agency3");
    xmlGet.find("agencyname");
    cfg43 = xmlGet.getString();
    xmlGet.find("ori");
    cfg44 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("configuration");
    xmlGet.findAndDescend("import");
    xmlGet.find("interface");
    cb = xmlGet.getInt();
    xmlGet.find("userid");
    cfg45 = xmlGet.getString();
    xmlGet.find("password");
    cfg46 = xmlGet.getString();
    xmlGet.find("inschedule");
    bool inschedule = xmlGet.getBool();
    xmlGet.find("inscheduletime");
    importschedule = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("export");
    xmlGet.find("interface");
    cc = xmlGet.getInt();
    xmlGet.find("systemID");
    cfg47 = xmlGet.getString();
    xmlGet.find("userid");
    cfg48 = xmlGet.getString();
    xmlGet.find("password");
    cfg49 = xmlGet.getString();
    xmlGet.find("outschedule");
    bool outschedule = xmlGet.getBool();
    xmlGet.find("outscheduletime");
    exportschedule = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("techcontact");
    xmlGet.find("techname");
    cfg50 = xmlGet.getString();
    xmlGet.find("userid");
    cfg51 = xmlGet.getString();
    xmlGet.find("phone");
    cfg52 = xmlGet.getString();
    xmlGet.find("email");
    cfg53 = xmlGet.getString();
    xmlGet.find("alerts");
    bool alerts = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.rise();
//load court
    ui->comboBox_SelectorCourt->setCurrentIndex(ca);
    ui->lineEdit_CourtID->setText(cfg1);
    ui->lineEdit_IssuingState->setText(cfg2);
    ui->lineEdit_CourtJudge->setText(cfg3);
    ui->lineEdit_CourtCEO->setText(cfg4);
//load location
    ui->treeWidget_Locations->setColumnCount(5);
    ui->treeWidget_Locations->setColumnWidth(0,100);
    ui->treeWidget_Locations->setColumnWidth(1,100);
    ui->treeWidget_Locations->setColumnWidth(2,300);
    ui->treeWidget_Locations->setColumnWidth(3,300);
    ui->treeWidget_Locations->setColumnWidth(4,100);
    ui->treeWidget_Locations->setHeaderLabels(QStringList() << "COURT" << "DIVISION" << "STREET ADDRESS" << "MAILING ADDRESS" << "COURT ID");
    AddCourtLocations(cfg5, cfg6, cfg7, cfg8, cfg9);
    AddCourtLocations(cfg10, cfg11, cfg12, cfg13, cfg14);
//load courtroom
    ui->treeWidget_Courtrooms->setColumnCount(3);
    ui->treeWidget_Courtrooms->setColumnWidth(0,150);
    ui->treeWidget_Courtrooms->setColumnWidth(1,150);
    ui->treeWidget_Courtrooms->setColumnWidth(2,150);
    ui->treeWidget_Courtrooms->setHeaderLabels(QStringList() << "LOCATION" << "COURTROOM NAME" << "JUDGE");
    AddCourtCourtrooms(cfg15, cfg16, cfg17);
    AddCourtCourtrooms(cfg18, cfg19, cfg20);
    AddCourtCourtrooms(cfg21, cfg22, cfg23);
    AddCourtCourtrooms(cfg24, cfg25, cfg26);
//load departments
    ui->treeWidget_Departments->setColumnCount(4);
    ui->treeWidget_Departments->setColumnWidth(0,150);
    ui->treeWidget_Departments->setColumnWidth(1,150);
    ui->treeWidget_Departments->setColumnWidth(2,200);
    ui->treeWidget_Departments->setColumnWidth(3,200);
    ui->treeWidget_Departments->setHeaderLabels(QStringList() << "DEPARTMENT NAME" << "ROOM" << "BRANCH OFFICER" << "COURT REPORTER");
    AddCourtDepartments(cfg27, cfg28, cfg29, cfg30);
    AddCourtDepartments(cfg31, cfg32, cfg33, cfg34);
    AddCourtDepartments(cfg35, cfg36, cfg37, cfg38);
//load agency ori
    ui->treeWidget_Agencies->setColumnCount(2);
    ui->treeWidget_Agencies->setColumnWidth(0,350);
    ui->treeWidget_Agencies->setColumnWidth(1,150);
    ui->treeWidget_Agencies->setHeaderLabels(QStringList() << "AGENCY" << "AGENCY ORI");
    AddCourtAgencies(cfg39, cfg40);
    AddCourtAgencies(cfg41, cfg42);
    AddCourtAgencies(cfg43, cfg44);
//load configuration in
    ui->comboBox_importInterface->setCurrentIndex(cb);
    ui->lineEdit_importUserID->setText(cfg45);
    ui->lineEdit_importPassword->setText(cfg46);
    ui->checkBox_importSchedule->setChecked(inschedule);
    QTime intime = QTime::fromString(importschedule,"hh:mm:ss");
    ui->timeEdit_importSchedule->setTime(intime);
//out
    ui->comboBox_exportInterface->setCurrentIndex(cc);
    ui->lineEdit_exportSystemID->setText(cfg47);
    ui->lineEdit_exportUserID->setText(cfg48);
    ui->lineEdit_exportPassword->setText(cfg49);
    ui->checkBox_exportSchedule->setChecked(outschedule);
    QTime outtime = QTime::fromString(exportschedule,"hh:mm:ss");
    ui->timeEdit_exportSchedule->setTime(outtime);
//tech
    ui->lineEdit_TechAdminName->setText(cfg50);
    ui->lineEdit_TechAdminUserID->setText(cfg51);
    ui->lineEdit_TechAdminPhone->setText(cfg52);
    ui->lineEdit_TechAdminEmail->setText(cfg53);
    ui->checkBox_emailAlerts->setChecked(alerts);
}

//CONFIGURE COURT ORDER TABLES
void MainWindow::AddRootChildrenOrder(QString entity3, QString fullname)
{
    QTreeWidgetItem *itm = new QTreeWidgetItem(ui->treeWidget_DV110OthersProtected);
    itm->setText(0,entity3);
    itm->setText(1,fullname);
    ui->treeWidget_DV110OthersProtected->addTopLevelItem(itm);
}

void MainWindow::AddRootPropertyControl(QString pcItem, QString pcDescription)
{
    QTreeWidgetItem *itm6 = new QTreeWidgetItem(ui->treeWidget_DV110PropertyControl);
    itm6->setText(0,pcItem);
    itm6->setText(1,pcDescription);
    ui->treeWidget_DV110PropertyControl->addTopLevelItem(itm6);
}

void MainWindow::AddRootDebtPayment(QString dpItem, QString dpPaymentTo, QString dpPaymentFor, QString dpPaymentFrom, QString dpDate)
{
    QTreeWidgetItem *itm7 = new QTreeWidgetItem(ui->treeWidget_DV110Payments);
    itm7->setText(0,dpItem);
    itm7->setText(1,dpPaymentTo);
    itm7->setText(2,dpPaymentFor);
    itm7->setText(3,dpPaymentFrom);
    itm7->setText(4,dpDate);
    ui->treeWidget_DV110Payments->addTopLevelItem(itm7);
}

void MainWindow::AddRootDV110Children(QString ccEntity, QString ccFname, QString ccLname, QString ccDOB, QString ccLegal, QString ccPhysical)
{
    QTreeWidgetItem *itm8 = new QTreeWidgetItem(ui->treeWidget_DV110Children);
    itm8->setText(0,ccEntity);
    itm8->setText(1,ccFname);
    itm8->setText(2,ccLname);
    itm8->setText(3,ccDOB);
    itm8->setText(4,ccLegal);
    itm8->setText(5,ccPhysical);
    ui->treeWidget_DV110Children->addTopLevelItem(itm8);
}

void MainWindow::AddRootDV130OtherProtect(QString entity130, QString fullname130)
{
    QTreeWidgetItem *itm10 = new QTreeWidgetItem(ui->treeWidget_DV130OthersProtected);
    itm10->setText(0,entity130);
    itm10->setText(1,fullname130);
    ui->treeWidget_DV130OthersProtected->addTopLevelItem(itm10);
}

void MainWindow::AddRootDV130Children(QString ccEntity, QString ccFname, QString ccLname, QString ccDOB, QString ccLegal, QString ccPhysical)
{
    QTreeWidgetItem *itm11 = new QTreeWidgetItem(ui->treeWidget_DV130Children);
    itm11->setText(0,ccEntity);
    itm11->setText(1,ccFname);
    itm11->setText(2,ccLname);
    itm11->setText(3,ccDOB);
    itm11->setText(4,ccLegal);
    itm11->setText(5,ccPhysical);
    ui->treeWidget_DV130Children->addTopLevelItem(itm11);
}

void MainWindow::AddRootDV130PropertyControl(QString pcItem, QString pcDescription)
{
    QTreeWidgetItem *itm12 = new QTreeWidgetItem(ui->treeWidget_DV130PropertyControl);
    itm12->setText(0,pcItem);
    itm12->setText(1,pcDescription);
    ui->treeWidget_DV130PropertyControl->addTopLevelItem(itm12);
}

void MainWindow::AddRootDV130DebtPayment(QString dpItem, QString dpPaymentTo, QString dpPaymentFor, QString dpPaymentFrom, QString dpDate)
{
    QTreeWidgetItem *itm13 = new QTreeWidgetItem(ui->treeWidget_DV130Payments);
    itm13->setText(0,dpItem);
    itm13->setText(1,dpPaymentTo);
    itm13->setText(2,dpPaymentFor);
    itm13->setText(3,dpPaymentFrom);
    itm13->setText(4,dpDate);
    ui->treeWidget_DV130Payments->addTopLevelItem(itm13);
}

void MainWindow::AddRootDV130ChildSupport(QString csFirst, QString csLast, QString csPaidTo, QString csAmount)
{
    QTreeWidgetItem *itm14 = new QTreeWidgetItem(ui->treeWidget_DV130ChildSupport);
    itm14->setText(0,csFirst);
    itm14->setText(1,csLast);
    itm14->setText(2,csPaidTo);
    itm14->setText(3,csAmount);
    ui->treeWidget_DV130ChildSupport->addTopLevelItem(itm14);
}

void MainWindow::AddRootDV130Income(QString csRole, QString csGross, QString csNet, QString csCalWork, QString csImputIncome, QString csImputMonth)
{
    QTreeWidgetItem *itm15 = new QTreeWidgetItem(ui->treeWidget_DV130Income);
    itm15->setText(0,csRole);
    itm15->setText(1,csGross);
    itm15->setText(2,csNet);
    itm15->setText(3,csCalWork);
    itm15->setText(4,csImputIncome);
    itm15->setText(5,csImputMonth);
    ui->treeWidget_DV130Income->addTopLevelItem(itm15);
}

void MainWindow::AddRootDV130Hardship(QString csHardship, QString csPetitioner, QString csRespondent, QString csOther, QString csEndDate)
{
    QTreeWidgetItem *itm16 = new QTreeWidgetItem(ui->treeWidget_DV130Hardship);
    itm16->setText(0,csHardship);
    itm16->setText(1,csPetitioner);
    itm16->setText(2,csRespondent);
    itm16->setText(3,csOther);
    itm16->setText(4,csEndDate);
    ui->treeWidget_DV130Hardship->addTopLevelItem(itm16);
}

void MainWindow::AddRootDV130FamilySupport(QString ssDesignation, QString ssFname, QString ssGross, QString ssDeductions, QString ssHardship, QString ssCalWorks, QString ssNet)
{
    QTreeWidgetItem *itm17 = new QTreeWidgetItem(ui->treeWidget_DV130FamilySupport);
    itm17->setText(0,ssDesignation);
    itm17->setText(1,ssFname);
    itm17->setText(2,ssGross);
    itm17->setText(3,ssDeductions);
    itm17->setText(4,ssHardship);
    itm17->setText(5,ssCalWorks);
    itm17->setText(6,ssNet);
    ui->treeWidget_DV130FamilySupport->addTopLevelItem(itm17);
}

void MainWindow::AddRootCH110OthersProtected(QString chEntity, QString chName, QString chRelation, QString chHousehold, QString chAge, QString chSex)
{
    QTreeWidgetItem *itm18 = new QTreeWidgetItem(ui->treeWidget_CH110OthersProtected);
    itm18->setText(0,chEntity);
    itm18->setText(1,chName);
    itm18->setText(2,chRelation);
    itm18->setText(3,chHousehold);
    itm18->setText(4,chAge);
    itm18->setText(5,chSex);
    ui->treeWidget_CH110OthersProtected->addTopLevelItem(itm18);
}

void MainWindow::AddRootCH110LawEnforcement(QString chAgency, QString chAddress)
{
    QTreeWidgetItem *itm19 = new QTreeWidgetItem(ui->treeWidget_CH110LawEnforcement);
    itm19->setText(0,chAgency);
    itm19->setText(1,chAddress);
    ui->treeWidget_CH110LawEnforcement->addTopLevelItem(itm19);
}


void MainWindow::AddRootCH130OthersProtected(QString chEntity, QString chName, QString chRelation, QString chHousehold, QString chAge, QString chSex)
{
    QTreeWidgetItem *itm20 = new QTreeWidgetItem(ui->treeWidget_CH130OthersProtected);
    itm20->setText(0,chEntity);
    itm20->setText(1,chName);
    itm20->setText(2,chRelation);
    itm20->setText(3,chHousehold);
    itm20->setText(4,chAge);
    itm20->setText(5,chSex);
    ui->treeWidget_CH130OthersProtected->addTopLevelItem(itm20);
}

void MainWindow::AddRootCH130LawEnforcement(QString chAgency, QString chAddress)
{
    QTreeWidgetItem *itm21 = new QTreeWidgetItem(ui->treeWidget_CH130LawEnforcement);
    itm21->setText(0,chAgency);
    itm21->setText(1,chAddress);
    ui->treeWidget_CH130LawEnforcement->addTopLevelItem(itm21);
}
void MainWindow::AddRootCH130Payments(QString chItem, QString chAmount)
{
    QTreeWidgetItem *itm22 = new QTreeWidgetItem(ui->treeWidget_CH130Payments);
    itm22->setText(0,chItem);
    itm22->setText(1,chAmount);
    ui->treeWidget_CH130Payments->addTopLevelItem(itm22);
}
void MainWindow::AddRootEA110OthersProtected(QString eaEntity, QString eaName, QString eaRelation, QString eaHousehold, QString eaAge, QString eaSex)
{
    QTreeWidgetItem *itm30 = new QTreeWidgetItem(ui->treeWidget_EA110OthersProtected);
    itm30->setText(0,eaEntity);
    itm30->setText(1,eaName);
    itm30->setText(2,eaRelation);
    itm30->setText(3,eaHousehold);
    itm30->setText(4,eaAge);
    itm30->setText(5,eaSex);
    ui->treeWidget_EA110OthersProtected->addTopLevelItem(itm30);
}

void MainWindow::AddRootEA110LawEnforcement(QString eaAgency, QString eaAddress)
{
    QTreeWidgetItem *itm31 = new QTreeWidgetItem(ui->treeWidget_EA110LawEnforcement);
    itm31->setText(0,eaAgency);
    itm31->setText(1,eaAddress);
    ui->treeWidget_EA110LawEnforcement->addTopLevelItem(itm31);
}

void MainWindow::AddRootEA130OthersProtected(QString eaEntity, QString eaName, QString eaRelation, QString eaHousehold, QString eaAge, QString eaSex)
{
    QTreeWidgetItem *itm40 = new QTreeWidgetItem(ui->treeWidget_EA130OthersProtected);
    itm40->setText(0,eaEntity);
    itm40->setText(1,eaName);
    itm40->setText(2,eaRelation);
    itm40->setText(3,eaHousehold);
    itm40->setText(4,eaAge);
    itm40->setText(5,eaSex);
    ui->treeWidget_EA130OthersProtected->addTopLevelItem(itm40);
}

void MainWindow::AddRootEA130LawEnforcement(QString eaAgency, QString eaAddress)
{
    QTreeWidgetItem *itm41 = new QTreeWidgetItem(ui->treeWidget_EA130LawEnforcement);
    itm41->setText(0,eaAgency);
    itm41->setText(1,eaAddress);
    ui->treeWidget_EA130LawEnforcement->addTopLevelItem(itm41);
}

void MainWindow::AddRootFL344Property(QString pcItem, QString pcGivenTo)
{
    QTreeWidgetItem *itm50 = new QTreeWidgetItem(ui->treeWidget_FL344PropertyControl);
    itm50->setText(0,pcItem);
    itm50->setText(1,pcGivenTo);
    ui->treeWidget_FL344PropertyControl->addTopLevelItem(itm50);
}

void MainWindow::AddRootFL344DebtPayment(QString pcDebt, QString pcPayment, QString pcDebtPayBy, QString pcDebtPayTo)
{
    QTreeWidgetItem *itm51 = new QTreeWidgetItem(ui->treeWidget_FL344Debt);
    itm51->setText(0,pcDebt);
    itm51->setText(1,pcPayment);
    itm51->setText(2,pcDebtPayBy);
    itm51->setText(3,pcDebtPayTo);
    ui->treeWidget_FL344Debt->addTopLevelItem(itm51);
}

void MainWindow::AddRootOtherProtected(QString entity1, QString fname, QString lname, QString relation, QString dob, QString sex)
{
    QTreeWidgetItem *itm1 = new QTreeWidgetItem(ui->treeWidget_otherProtected);
    itm1->setText(0,entity1);
    itm1->setText(1,fname);
    itm1->setText(2,lname);
    itm1->setText(3,relation);
    itm1->setText(4,dob);
    itm1->setText(5,sex);
    ui->treeWidget_otherProtected->addTopLevelItem(itm1);
}

void MainWindow::AddRootChildren(QString entitychild, QString fnamechild, QString lnamechild, QString relationchild, QString dobchild, QString sexchild)
{
    QTreeWidgetItem *itm1 = new QTreeWidgetItem(ui->treeWidget_childrenList);
    itm1->setText(0,entitychild);
    itm1->setText(1,fnamechild);
    itm1->setText(2,lnamechild);
    itm1->setText(3,relationchild);
    itm1->setText(4,dobchild);
    itm1->setText(5,sexchild);
    ui->treeWidget_childrenList->addTopLevelItem(itm1);
}

void MainWindow::AddRootWitness(QString entitywitness, QString fnamewitness, QString lnamewitness, QString designationwitness, QString partywitness, QString contactwitness)
{
    QTreeWidgetItem *itm2 = new QTreeWidgetItem(ui->treeWidget_Witness);
    itm2->setText(0,entitywitness);
    itm2->setText(1,fnamewitness);
    itm2->setText(2,lnamewitness);
    itm2->setText(3,designationwitness);
    itm2->setText(4,partywitness);
    itm2->setText(5,contactwitness);
    ui->treeWidget_Witness->addTopLevelItem(itm2);
}

void MainWindow::AddRootInterpreter(QString entityinterpreter, QString fnameinterpreter, QString lnameinterpreter, QString designationinterpreter, QString partyinterpreter, QString contactinterpreter)
{
    QTreeWidgetItem *itm3 = new QTreeWidgetItem(ui->treeWidget_Interpreter);
    itm3->setText(0,entityinterpreter);
    itm3->setText(1,fnameinterpreter);
    itm3->setText(2,lnameinterpreter);
    itm3->setText(3,designationinterpreter);
    itm3->setText(4,partyinterpreter);
    itm3->setText(5,contactinterpreter);
    ui->treeWidget_Interpreter->addTopLevelItem(itm3);
}

void MainWindow::AddRootRelatedCase(QString casenumber, QString casetype, QString county, QString CPO, QString expiration, QString leadcase)
{
    QTreeWidgetItem *itm4 = new QTreeWidgetItem(ui->treeWidget_relatedCases);
    itm4->setText(0,casenumber);
    itm4->setText(1,casetype);
    itm4->setText(2,county);
    itm4->setText(3,CPO);
    itm4->setText(4,expiration);
    itm4->setText(5,leadcase);
    ui->treeWidget_relatedCases->addTopLevelItem(itm4);
}

void MainWindow::AddRootCaseHistory(QString date, QString event, QString p1present, QString p1sworn, QString p1atty, QString p2present, QString p2sworn, QString p2atty, QString orders, QString mergecase)
{
    QTreeWidgetItem *itm5 = new QTreeWidgetItem(ui->treeWidget_caseHistory);
    itm5->setText(0,date);
    itm5->setText(1,event);
    itm5->setText(2,p1present);
    itm5->setText(3,p1sworn);
    itm5->setText(4,p1atty);
    itm5->setText(5,p2present);
    itm5->setText(6,p2sworn);
    itm5->setText(7,p2atty);
    itm5->setText(8,orders);
    itm5->setText(9,mergecase);
    ui->treeWidget_caseHistory->addTopLevelItem(itm5);
}

void MainWindow::ResetRecordTables()
{
   ui->treeWidget_childrenList->clear();
   ui->treeWidget_otherProtected->clear();
   ui->treeWidget_Witness->clear();
   ui->treeWidget_Interpreter->clear();
   ui->treeWidget_relatedCases->clear();
   ui->treeWidget_caseHistory->clear();
}

void MainWindow::ResetOrderTables()
{
   ui->treeWidget_DV110OthersProtected->clear();
   ui->treeWidget_DV110Children->clear();
   ui->treeWidget_DV110PropertyControl->clear();
   ui->treeWidget_DV110Payments->clear();
   ui->treeWidget_DV130OthersProtected->clear();
   ui->treeWidget_DV130Children->clear();
   ui->treeWidget_DV130PropertyControl->clear();
   ui->treeWidget_DV130Payments->clear();
   ui->treeWidget_DV130ChildSupport->clear();
   ui->treeWidget_DV130FamilySupport->clear();
   ui->treeWidget_DV130Income->clear();
   ui->treeWidget_DV130Hardship->clear();
   ui->treeWidget_CH110OthersProtected->clear();
   ui->treeWidget_CH110LawEnforcement->clear();
   ui->treeWidget_CH130OthersProtected->clear();
   ui->treeWidget_CH130LawEnforcement->clear();
   ui->treeWidget_CH130Payments->clear();
   ui->treeWidget_EA110OthersProtected->clear();
   ui->treeWidget_EA110LawEnforcement->clear();
   ui->treeWidget_EA130OthersProtected->clear();
   ui->treeWidget_EA130LawEnforcement->clear();
   ui->treeWidget_FL344PropertyControl->clear();
   ui->treeWidget_FL344Debt->clear();
}

void MainWindow::LoadCaseHeader()
{

//GET CASE FLAT FILE
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

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

//READ CASE FILE HEADER INFO
    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.findAndDescend("caseorders");
    xmlGet.findAndDescend("caseheader");
    xmlGet.find("caseNumber");
    str1 = xmlGet.getString();
    xmlGet.find("tempJudge");
    bool tempJudge = xmlGet.getBool();
    xmlGet.find("tempJudgeName");
    str2 = xmlGet.getString();
    xmlGet.find("currentOrder");
    str3 = xmlGet.getString();
    xmlGet.find("currentExpireDate");
    str12 = xmlGet.getString();
    xmlGet.find("sealedCase");
    bool sealedcase = xmlGet.getBool();
    xmlGet.find("confidentialCase");
    bool confidentialcase = xmlGet.getBool();
    xmlGet.find("p1Name");
    str4 = xmlGet.getString();
    xmlGet.find("p1Attend");
    bool p1Attend = xmlGet.getBool();
    xmlGet.find("p1Sworn");
    bool p1Sworn = xmlGet.getBool();
    xmlGet.find("p1Attorney");
    bool p1Attorney = xmlGet.getBool();
    xmlGet.find("p1Parent");
    str5 = xmlGet.getString();
    xmlGet.find("p1Role");
    str6 = xmlGet.getString();
    xmlGet.find("p1Designation");
    str7 = xmlGet.getString();
    xmlGet.find("p2Name");
    str8 = xmlGet.getString();
    xmlGet.find("p2Attend");
    bool p2Attend = xmlGet.getBool();
    xmlGet.find("p2Sworn");
    bool p2Sworn = xmlGet.getBool();
    xmlGet.find("p2Attorney");
    bool p2Attorney = xmlGet.getBool();
    xmlGet.find("p2Parent");
    str9 = xmlGet.getString();
    xmlGet.find("p2Role");
    str10 = xmlGet.getString();
    xmlGet.find("p2Designation");
    str11 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
//LOAD UI
    ui->lineEdit_ordersCaseNumber->setText(str1);
    ui->checkBox_sealedCase->setChecked(sealedcase);
    ui->checkBox_confidentialCase->setChecked(confidentialcase);
    ui->checkBox_tempJudge->setChecked(tempJudge);
    ui->lineEdit_tempJudgeName->setText(str2);
    ui->lineEdit_currentOrders->setText(str3);
    ui->lineEdit_currentExpireDate->setText(str12);
    ui->lineEdit_p1OrderName->setText(str4);
    ui->checkBox_p1Attend->setChecked(p1Attend);
    ui->checkBox_p1Sworn->setChecked(p1Sworn);
    ui->checkBox_p1AttorneyAttend->setChecked(p1Attorney);
    ui->lineEdit_p1Parent->setText(str5);
    ui->lineEdit_p1OrderRole->setText(str6);
    ui->lineEdit_p1OrderDesignation->setText(str7);
    ui->lineEdit_p2OrderName->setText(str8);
    ui->checkBox_p2Attend->setChecked(p2Attend);
    ui->checkBox_p2Sworn->setChecked(p2Sworn);
    ui->checkBox_p2AttorneyAttend->setChecked(p2Attorney);
    ui->lineEdit_p2Parent->setText(str9);
    ui->lineEdit_p2OrderRole->setText(str10);
    ui->lineEdit_p2OrderDesignation->setText(str11);
}



//LOAD CASE RECORD DATASET
void MainWindow::LoadCaseRecord()
{
    QString listid;
    listid = ui->listWidget_listCaseRecord->currentItem()->text();
    QStringList caseid;
    caseid << "/users/jamesreid/cases/" << listid << ".xml";
    QString loadfile = caseid.join("");

    QString str100;
    QString str101;
    QString str102;
    QString str103;
    QString str104;
    QString str105;
    QString str106;
    QString str107;
    QString str108;
    QString str109;
    QString str110;
    QString str111;
    QString str112;
    QString str113;
    QString str114;
    QString str115;
    QString str116;
    QString str117;
    QString str118;
    QString str119;
    QString str120;
    QString str121;
    QString str122;
    QString str123;
    QString str124;
    QString str125;
    QString str126;
    QString str127;
    QString str128;
    QString str129;
    QString str130;
    QString str131;
    QString str132;
    QString str133;
    QString str134;
    QString str135;
    QString str136;
    QString str137;
    QString str138;
    QString str139;
    QString str140;
    QString str141;
    QString str142;
    QString str143;
    QString str144;
    QString str145;
    QString str146;
    QString str147;
    QString str148;
    QString str149;
    QString str150;
    QString str151;
    QString str152;
    QString str153;
    QString str154;
    QString str155;
    QString str156;
    QString str157;
    QString str158;
    QString str170;
    QString str171;
    QString str172;
    QString str173;
    QString str174;
    QString str175;
    QString str176;
    QString str177;
    QString str178;
    QString str179;
    QString str180;
    QString str181;
    QString str182;
    QString str183;
    QString str184;
    QString str185;
    QString str186;
    QString str187;
    QString str188;
    QString str189;
    QString str190;
    QString str191;
    QString str192;
    QString str193;
    QString str194;
    QString str195;
    QString str196;
    QString str197;
    QString str198;
    QString str199;
    QString str200;
    QString str201;
    QString str202;
    QString str203;
    QString str204;
    QString str205;
    QString str206;
    QString str207;
    QString str208;
    QString str209;
    QString str210;
    QString str211;
    QString str212;
    QString str213;
    QString str214;
    QString str215;
    QString str216;
    QString str217;
    QString str218;
    QString str219;
    QString str220;
    QString str221;
    QString str222;
    QString str223;
    QString str224;
    QString str225;
    QString str226;
    QString str227;
    QString str228;
    QString str229;
    QString str230;
    QString str231;
    QString str232;
    QString str233;
    QString str234;
    QString str235;
    QString str236;
    QString str237;
    QString str238;
    QString str239;
    QString str240;
    QString str241;
    QString str242;
    QString str243;
    QString str244;
    QString str245;
    QString str246;
    QString str247;
    QString str248;
    QString str249;
    QString str250;
    QString str251;
    QString str252;
    QString str253;
    QString str254;
    QString str255;
    QString str256;
    QString str257;
    QString str258;
    QString str259;
    QString str260;
    QString str261;
    QString str262;
    QString str263;
    QString str264;
    QString str265;
    QString str266;
    QString str267;
    QString str268;
    QString str269;
    QString str270;
    QString str271;
    QString str272;
    QString str273;
    QString str274;
    QString str275;
    QString str276;
    QString str277;
    QString str278;
    QString str279;
    QString str280;
    QString str281;
    QString str282;
    QString str283;
    QString str284;
    QString str285;
    QString str286;
    QString str287;
    QString str288;
    QString str289;

    QString str300;
    QString str301;
    QString str302;
    QString str303;
    QString str304;
    QString str305;
    QString str306;
    QString str307;
    QString str308;
    QString str309;
    QString str310;
    QString str311;
    QString str312;
    QString str313;
    QString str314;
    QString str315;
    QString str316;
    QString str317;
    QString str318;
    QString str319;
    QString str320;
    QString str321;

    int a, b, c, d, e, f, g, h, j, k, i, l, m, n, o ,p;

    QXmlGet xmlGet;
    xmlGet.load(loadfile);
    xmlGet.find("caserecord");
    xmlGet.findAndDescend("caseheader");
    xmlGet.find("caseNumber");
    str154 = xmlGet.getString();
    xmlGet.find("caseFileDate");
    str155 = xmlGet.getString();
    xmlGet.find("caseStatus");
    str156 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("parties");
    xmlGet.findAndDescend("party1");
//PARTY 1
    xmlGet.find("p1FirstName");
    str100 = xmlGet.getString();
    xmlGet.find("p1MiddleName");
    str101 = xmlGet.getString();
    xmlGet.find("p1LastName");
    str102 = xmlGet.getString();
    xmlGet.find("p1Role");
    a = xmlGet.getInt();
    xmlGet.find("p1Designation");
    b = xmlGet.getInt();
    xmlGet.find("p1Description");
    str103 = xmlGet.getString();
    xmlGet.find("p1Relationship");
    c = xmlGet.getInt();
    xmlGet.find("p1Hair");
    d = xmlGet.getInt();
    xmlGet.find("p1Eyes");
    e = xmlGet.getInt();
    xmlGet.find("p1Sex");
    f = xmlGet.getInt();
    xmlGet.find("p1Race");
    g = xmlGet.getInt();
    xmlGet.find("p1Age");
    str104 = xmlGet.getString();
    xmlGet.find("p1Parentrole");
    h = xmlGet.getInt();
    xmlGet.find("p1Weight");
    str105 = xmlGet.getString();
    xmlGet.find("p1HeightFeet");
    str106 = xmlGet.getString();
    xmlGet.find("p1HeightInch");
    str107 = xmlGet.getString();
    xmlGet.find("p1DOB");
    str108 = xmlGet.getString();
    xmlGet.find("p1AddressStreet");
    str109 = xmlGet.getString();
    xmlGet.find("p1AddressCity");
    str110 = xmlGet.getString();
    xmlGet.find("p1AddressState");
    str111 = xmlGet.getString();
    xmlGet.find("p1AddressPostal");
    str112 = xmlGet.getString();
    xmlGet.find("p1Phone");
    str113 = xmlGet.getString();
    xmlGet.find("p1Fax");
    str114 = xmlGet.getString();
    xmlGet.find("p1Email");
    str115 = xmlGet.getString();
//PARTY 1 ATTORNEY
    xmlGet.find("p1ProPer");
    bool p1ProPer = xmlGet.getBool();
    xmlGet.find("p1Attorney");
    bool p1Attorney = xmlGet.getBool();
    xmlGet.find("p1AttorneyFirstName");
    str116 = xmlGet.getString();
    xmlGet.find("p1AttorneyLastName");
    str117 = xmlGet.getString();
    xmlGet.find("p1AttorneyBarID");
    str118 = xmlGet.getString();
    xmlGet.find("p1AttorneyFirmName");
    str119 = xmlGet.getString();
    xmlGet.find("p1AttorneyAddressStreet");
    str120 = xmlGet.getString();
    xmlGet.find("p1AttorneyAddressCity");
    str121 = xmlGet.getString();
    xmlGet.find("p1AttorneyAddressState");
    str122 = xmlGet.getString();
    xmlGet.find("p1AttorneyAddressPostal");
    str123 = xmlGet.getString();
    xmlGet.find("p1AttorneyPhone");
    str124 = xmlGet.getString();
    xmlGet.find("p1AttorneyFax");
    str125 = xmlGet.getString();
    xmlGet.find("p1AttorneyEmail");
    str126 = xmlGet.getString();
    xmlGet.rise();
//PARTY 2
    xmlGet.findAndDescend("party2");
    xmlGet.find("p2FirstName");
    str127 = xmlGet.getString();
    xmlGet.find("p2MiddleName");
    str128 = xmlGet.getString();
    xmlGet.find("p2LastName");
    str129 = xmlGet.getString();
    xmlGet.find("p2Role");
    i = xmlGet.getInt();
    xmlGet.find("p2Designation");
    j = xmlGet.getInt();
    xmlGet.find("p2Description");
    str130 = xmlGet.getString();
    xmlGet.find("p2Relationship");
    k = xmlGet.getInt();
    xmlGet.find("p2Hair");
    l = xmlGet.getInt();
    xmlGet.find("p2Eyes");
    m = xmlGet.getInt();
    xmlGet.find("p2Sex");
    n = xmlGet.getInt();
    xmlGet.find("p2Race");
    o = xmlGet.getInt();
    xmlGet.find("p2Age");
    str131 = xmlGet.getString();
    xmlGet.find("p2Parentrole");
    p = xmlGet.getInt();
    xmlGet.find("p2Weight");
    str132 = xmlGet.getString();
    xmlGet.find("p2HeightFeet");
    str133 = xmlGet.getString();
    xmlGet.find("p2HeightInch");
    str134 = xmlGet.getString();
    xmlGet.find("p2DOB");
    str135 = xmlGet.getString();
    xmlGet.find("p2AddressStreet");
    str136 = xmlGet.getString();
    xmlGet.find("p2AddressCity");
    str137 = xmlGet.getString();
    xmlGet.find("p2AddressState");
    str138 = xmlGet.getString();
    xmlGet.find("p2AddressPostal");
    str139 = xmlGet.getString();
    xmlGet.find("p2Phone");
    str140 = xmlGet.getString();
    xmlGet.find("p2Fax");
    str141 = xmlGet.getString();
    xmlGet.find("p2Email");
    str142 = xmlGet.getString();
//PARTY 2 ATTORNEY
    xmlGet.find("p2ProPer");
    bool p2ProPer = xmlGet.getBool();
    xmlGet.find("p2Attorney");
    bool p2Attorney = xmlGet.getBool();
    xmlGet.find("p2AttorneyFirstName");
    str143 = xmlGet.getString();
    xmlGet.find("p2AttorneyLastName");
    str144 = xmlGet.getString();
    xmlGet.find("p2AttorneyBarID");
    str145 = xmlGet.getString();
    xmlGet.find("p2AttorneyFirmName");
    str146 = xmlGet.getString();
    xmlGet.find("p2AttorneyAddressStreet");
    str147 = xmlGet.getString();
    xmlGet.find("p2AttorneyAddressCity");
    str148 = xmlGet.getString();
    xmlGet.find("p2AttorneyAddressState");
    str149 = xmlGet.getString();
    xmlGet.find("p2AttorneyAddressPostal");
    str150 = xmlGet.getString();
    xmlGet.find("p2AttorneyPhone");
    str151 = xmlGet.getString();
    xmlGet.find("p2AttorneyFax");
    str152 = xmlGet.getString();
    xmlGet.find("p2AttorneyEmail");
    str153 = xmlGet.getString();
    xmlGet.rise();   
    xmlGet.findAndDescend("party3");
    xmlGet.find("p3ProPer");
    bool p3ProPer = xmlGet.getBool();
    xmlGet.find("p3AttorneyFirstName");
    str300 = xmlGet.getString();
    xmlGet.find("p3AttorneyLastName");
    str301 = xmlGet.getString();
    xmlGet.find("p3AttorneyBarID");
    str302 = xmlGet.getString();
    xmlGet.find("p3AttorneyFirmName");
    str303 = xmlGet.getString();
    xmlGet.find("p3AttorneyAddressStreet");
    str304 = xmlGet.getString();
    xmlGet.find("p3AttorneyAddressCity");
    str305 = xmlGet.getString();
    xmlGet.find("p3AttorneyAddressState");
    str306 = xmlGet.getString();
    xmlGet.find("p3AttorneyAddressPostal");
    str307= xmlGet.getString();
    xmlGet.find("p3AttorneyPhone");
    str308 = xmlGet.getString();
    xmlGet.find("p3AttorneyFax");
    str309 = xmlGet.getString();
    xmlGet.find("p3AttorneyEmail");
    str310 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.find("childattorney");
    xmlGet.descend();
    xmlGet.find("c1AttorneyFirstName");
    str311 = xmlGet.getString();
    xmlGet.find("c1AttorneyLastName");
    str312 = xmlGet.getString();
    xmlGet.find("c1AttorneyBarID");
    str313 = xmlGet.getString();
    xmlGet.find("c1AttorneyFirmName");
    str314 = xmlGet.getString();
    xmlGet.find("c1AttorneyAddressStreet");
    str315 = xmlGet.getString();
    xmlGet.find("c1AttorneyAddressCity");
    str316 = xmlGet.getString();
    xmlGet.find("c1AttorneyAddressState");
    str317 = xmlGet.getString();
    xmlGet.find("c1AttorneyAddressPostal");
    str318= xmlGet.getString();
    xmlGet.find("c1AttorneyPhone");
    str319 = xmlGet.getString();
    xmlGet.find("c1AttorneyFax");
    str320 = xmlGet.getString();
    xmlGet.find("c1AttorneyEmail");
    str321 = xmlGet.getString();
    xmlGet.rise();
//CHILDREN OTHER PROTECTED
    xmlGet.findAndDescend("children");
    xmlGet.findAndDescend("child1");
    xmlGet.find("entity");
    str170 = xmlGet.getString();
    xmlGet.find("firstname");
    str171 = xmlGet.getString();
    xmlGet.find("lastname");
    str172 = xmlGet.getString();
    xmlGet.find("relationship");
    str173 = xmlGet.getString();
    xmlGet.find("dateofbirth");
    str174 = xmlGet.getString();
    xmlGet.find("sex");
    str175 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("child2");
    xmlGet.findNext("entity");
    str176 = xmlGet.getString();
    xmlGet.findNext("firstname");
    str177 = xmlGet.getString();
    xmlGet.findNext("lastname");
    str178 = xmlGet.getString();
    xmlGet.findNext("relationship");
    str179 = xmlGet.getString();
    xmlGet.findNext("dateofbirth");
    str180 = xmlGet.getString();
    xmlGet.findNext("sex");
    str181 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("otherprotected");
    xmlGet.findAndDescend("otherprotected1");
    xmlGet.find("entity");
    str182 = xmlGet.getString();
    xmlGet.find("firstname");
    str183 = xmlGet.getString();
    xmlGet.find("lastname");
    str184 = xmlGet.getString();
    xmlGet.find("relationship");
    str185 = xmlGet.getString();
    xmlGet.find("household");
    str186 = xmlGet.getString();
    xmlGet.find("sex");
    str187 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
//OTHER ENTITIES
    xmlGet.findAndDescend("witness");
    xmlGet.findAndDescend("witness1");
    xmlGet.find("entity");
    str188 = xmlGet.getString();
    xmlGet.find("firstname");
    str189 = xmlGet.getString();
    xmlGet.find("lastname");
    str190 = xmlGet.getString();
    xmlGet.find("designation");
    str191 = xmlGet.getString();
    xmlGet.find("witnessfor");
    str192 = xmlGet.getString();
    xmlGet.find("contactinfo");
    str193 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("witness2");
    xmlGet.find("entity");
    str194 = xmlGet.getString();
    xmlGet.find("firstname");
    str195 = xmlGet.getString();
    xmlGet.find("lastname");
    str196 = xmlGet.getString();
    xmlGet.find("designation");
    str197 = xmlGet.getString();
    xmlGet.find("witnessfor");
    str198 = xmlGet.getString();
    xmlGet.find("contactinfo");
    str199 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("interpreter");
    xmlGet.findAndDescend("interpreter1");
    xmlGet.find("entity");
    str200 = xmlGet.getString();
    xmlGet.find("firstname");
    str201 = xmlGet.getString();
    xmlGet.find("lastname");
    str202 = xmlGet.getString();
    xmlGet.find("designation");
    str203 = xmlGet.getString();
    xmlGet.find("interpreterfor");
    str204 = xmlGet.getString();
    xmlGet.find("language");
    str205 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
//RELATED CASES
    xmlGet.findAndDescend("relatedcases");
    xmlGet.findAndDescend("case1");
    xmlGet.find("casenumber");
    str206 = xmlGet.getString();
    xmlGet.find("casetype");
    str207 = xmlGet.getString();
    xmlGet.find("county");
    str208 = xmlGet.getString();
    xmlGet.find("CPOTRO");
    str209 = xmlGet.getString();
    xmlGet.find("expirationdate");
    str210 = xmlGet.getString();
    xmlGet.find("leadcase");
    str211 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("case2");
    xmlGet.find("casenumber");
    str212 = xmlGet.getString();
    xmlGet.find("casetype");
    str213 = xmlGet.getString();
    xmlGet.find("county");
    str214 = xmlGet.getString();
    xmlGet.find("CPOTRO");
    str215 = xmlGet.getString();
    xmlGet.find("expirationdate");
    str216 = xmlGet.getString();
    xmlGet.find("leadcase");
    str217 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("case3");
    xmlGet.find("casenumber");
    str218 = xmlGet.getString();
    xmlGet.find("casetype");
    str219 = xmlGet.getString();
    xmlGet.find("county");
    str220 = xmlGet.getString();
    xmlGet.find("CPOTRO");
    str221 = xmlGet.getString();
    xmlGet.find("expirationdate");
    str222 = xmlGet.getString();
    xmlGet.find("leadcase");
    str223 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
//CASE HISTORY
    xmlGet.findAndDescend("casehistory");
    xmlGet.findAndDescend("event1");
    xmlGet.find("date");
    str224 = xmlGet.getString();
    xmlGet.find("event");
    str225 = xmlGet.getString();
    xmlGet.find("party1present");
    str226 = xmlGet.getString();
    xmlGet.find("party1sworn");
    str227 = xmlGet.getString();
    xmlGet.find("party1atty");
    str228 = xmlGet.getString();
    xmlGet.find("party2present");
    str229 = xmlGet.getString();
    xmlGet.find("party2sworn");
    str230 = xmlGet.getString();
    xmlGet.find("party2atty");
    str231 = xmlGet.getString();
    xmlGet.find("orders");
    str232 = xmlGet.getString();
    xmlGet.find("mergedCase");
    str233 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("event2");
    xmlGet.findNext("date");
    str234 = xmlGet.getString();
    xmlGet.findNext("event");
    str235 = xmlGet.getString();
    xmlGet.findNext("party1present");
    str236 = xmlGet.getString();
    xmlGet.findNext("party1sworn");
    str237 = xmlGet.getString();
    xmlGet.findNext("party1atty");
    str238 = xmlGet.getString();
    xmlGet.findNext("party2present");
    str239 = xmlGet.getString();
    xmlGet.findNext("party2sworn");
    str240 = xmlGet.getString();
    xmlGet.findNext("party2atty");
    str241 = xmlGet.getString();
    xmlGet.findNext("orders");
    str242 = xmlGet.getString();
    xmlGet.findNext("mergedCase");
    str243 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("event3");
    xmlGet.find("date");
    str244 = xmlGet.getString();
    xmlGet.find("event");
    str245 = xmlGet.getString();
    xmlGet.find("party1present");
    str246 = xmlGet.getString();
    xmlGet.find("party1sworn");
    str247 = xmlGet.getString();
    xmlGet.find("party1atty");
    str248 = xmlGet.getString();
    xmlGet.find("party2present");
    str249 = xmlGet.getString();
    xmlGet.find("party2sworn");
    str250 = xmlGet.getString();
    xmlGet.find("party2atty");
    str251 = xmlGet.getString();
    xmlGet.find("orders");
    str252 = xmlGet.getString();
    xmlGet.find("mergedCase");
    str253 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("event4");
    xmlGet.find("date");
    str254 = xmlGet.getString();
    xmlGet.find("event");
    str255 = xmlGet.getString();
    xmlGet.find("party1present");
    str256 = xmlGet.getString();
    xmlGet.find("party1sworn");
    str257 = xmlGet.getString();
    xmlGet.find("party1atty");
    str258 = xmlGet.getString();
    xmlGet.find("party2present");
    str259 = xmlGet.getString();
    xmlGet.find("party2sworn");
    str260 = xmlGet.getString();
    xmlGet.find("party2atty");
    str261 = xmlGet.getString();
    xmlGet.find("orders");
    str262 = xmlGet.getString();
    xmlGet.find("mergedCase");
    str263 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("event5");
    xmlGet.find("date");
    str264 = xmlGet.getString();
    xmlGet.find("event");
    str265 = xmlGet.getString();
    xmlGet.find("party1present");
    str266 = xmlGet.getString();
    xmlGet.find("party1sworn");
    str267 = xmlGet.getString();
    xmlGet.find("party1atty");
    str268 = xmlGet.getString();
    xmlGet.find("party2present");
    str269 = xmlGet.getString();
    xmlGet.find("party2sworn");
    str270 = xmlGet.getString();
    xmlGet.find("party2atty");
    str271 = xmlGet.getString();
    xmlGet.find("orders");
    str272 = xmlGet.getString();
    xmlGet.find("mergedCase");
    str273 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
//CASE NOTES
    xmlGet.findAndDescend("casenotes");
    xmlGet.findAndDescend("user1");
    xmlGet.find("userid");
    str274 = xmlGet.getString();
    xmlGet.find("userrole");
    str275 = xmlGet.getString();
    xmlGet.find("lastdate");
    str276 = xmlGet.getString();
    xmlGet.find("publicnotes");
    str277 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("user2");
    xmlGet.find("userid");
    str278 = xmlGet.getString();
    xmlGet.find("userrole");
    str279 = xmlGet.getString();
    xmlGet.find("lastdate");
    str280 = xmlGet.getString();
    xmlGet.find("publicnotes");
    str281 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("user3");
    xmlGet.find("userid");
    str282 = xmlGet.getString();
    xmlGet.find("userrole");
    str283 = xmlGet.getString();
    xmlGet.find("lastdate");
    str284 = xmlGet.getString();
    xmlGet.find("publicnotes");
    str285 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("user4");
    xmlGet.findNext("userid");
    str286 = xmlGet.getString();
    xmlGet.findNext("userrole");
    str287 = xmlGet.getString();
    xmlGet.findNext("lastdate");
    str288 = xmlGet.getString();
    xmlGet.findNext("publicnotes");
    str289 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();

//PARTY 1
    ui->lineEdit_p1FirstName->setText(str100);
    ui->lineEdit_p1MiddleName->setText(str101);
    ui->lineEdit_p1LastName->setText(str102);
    ui->comboBox_p1Role->setCurrentIndex(a);
    ui->comboBox_p1Designation->setCurrentIndex(b);
    ui->lineEdit_p1Description->setText(str103);
    ui->comboBox_p1Relationship->setCurrentIndex(c);
    ui->comboBox_p1Hair->setCurrentIndex(d);
    ui->comboBox_p1Eyes->setCurrentIndex(e);
    ui->comboBox_p1Sex->setCurrentIndex(f);
    ui->comboBox_p1Race->setCurrentIndex(g);
    ui->lineEdit_p1Age->setText(str104);
    ui->comboBox_p1ParentRole->setCurrentIndex(h);
    ui->lineEdit_p1Weight->setText(str105);
    ui->lineEdit_p1HeightFeet->setText(str106);
    ui->lineEdit_p1HeightInch->setText(str107);
    ui->lineEdit_p1DOB->setText(str108);
    ui->lineEdit_p1AddressStreet->setText(str109);
    ui->lineEdit_p1AddressCity->setText(str110);
    ui->lineEdit_p1AddressState->setText(str111);
    ui->lineEdit_p1AddressPostal->setText(str112);
    ui->lineEdit_p1Phone->setText(str113);
    ui->lineEdit_p1Fax->setText(str114);
    ui->lineEdit_p1Email->setText(str115);
    ui->checkBox_p1Attorney_ProPer->setChecked(p1ProPer);
    ui->lineEdit_p1Attorney_FirstName->setText(str116);
    ui->lineEdit_p1Attorney_LastName->setText(str117);
    ui->lineEdit_p1Attorney_BarID->setText(str118);
    ui->lineEdit_p1Attorney_FirmName->setText(str119);
    ui->lineEdit_p1Attorney_AddressStreet->setText(str120);
    ui->lineEdit_p1Attorney_AddressCity->setText(str121);
    ui->lineEdit_p1Attorney_AddressState->setText(str122);
    ui->lineEdit_p1Attorney_AddressPostal->setText(str123);
    ui->lineEdit_p1Attorney_Phone->setText(str124);
    ui->lineEdit_p1Attorney_Fax->setText(str125);
    ui->lineEdit_p1Attorney_Email->setText(str126);

//Party2
    ui->lineEdit_p2FirstName->setText(str127);
    ui->lineEdit_p2MiddleName->setText(str128);
    ui->lineEdit_p2LastName->setText(str129);
    ui->comboBox_p2Role->setCurrentIndex(i);
    ui->comboBox_p2Designation->setCurrentIndex(j);
    ui->lineEdit_p2Description->setText(str130);
    ui->comboBox_p2Relationship->setCurrentIndex(k);
    ui->comboBox_p2Hair->setCurrentIndex(l);
    ui->comboBox_p2Eyes->setCurrentIndex(m);
    ui->comboBox_p2Sex->setCurrentIndex(n);
    ui->comboBox_p2Race->setCurrentIndex(o);
    ui->lineEdit_p2Age->setText(str131);
    ui->comboBox_p2ParentRole->setCurrentIndex(p);
    ui->lineEdit_p2Weight->setText(str132);
    ui->lineEdit_p2HeightFeet->setText(str133);
    ui->lineEdit_p2HeightInch->setText(str134);
    ui->lineEdit_p2DOB->setText(str135);
    ui->lineEdit_p2AddressStreet->setText(str136);
    ui->lineEdit_p2AddressCity->setText(str137);
    ui->lineEdit_p2AddressState->setText(str138);
    ui->lineEdit_p2AddressPostal->setText(str139);
    ui->lineEdit_p2Phone->setText(str140);
    ui->lineEdit_p2Fax->setText(str141);
    ui->lineEdit_p2Email->setText(str142);
    ui->checkBox_p2Attorney_ProPer->setChecked(p2ProPer);
    ui->lineEdit_p2Attorney_FirstName->setText(str143);
    ui->lineEdit_p2Attorney_LastName->setText(str144);
    ui->lineEdit_p2Attorney_BarID->setText(str145);
    ui->lineEdit_p2Attorney_FirmName->setText(str146);
    ui->lineEdit_p2Attorney_AddressStreet->setText(str147);
    ui->lineEdit_p2Attorney_AddressCity->setText(str148);
    ui->lineEdit_p2Attorney_AddressState->setText(str149);
    ui->lineEdit_p2Attorney_AddressPostal->setText(str150);
    ui->lineEdit_p2Attorney_Phone->setText(str151);
    ui->lineEdit_p2Attorney_Fax->setText(str152);
    ui->lineEdit_p2Attorney_Email->setText(str153);

    ui->checkBox_p3Attorney_ProPer->setChecked(p3ProPer);
    ui->lineEdit_p3Attorney_FirstName->setText(str300);
    ui->lineEdit_p3Attorney_LastName->setText(str301);
    ui->lineEdit_p3Attorney_BarID->setText(str302);
    ui->lineEdit_p3Attorney_FirmName->setText(str303);
    ui->lineEdit_p3Attorney_AddressStreet->setText(str304);
    ui->lineEdit_p3Attorney_AddressCity->setText(str305);
    ui->lineEdit_p3Attorney_AddressState->setText(str306);
    ui->lineEdit_p3Attorney_AddressPostal->setText(str307);
    ui->lineEdit_p3Attorney_Phone->setText(str308);
    ui->lineEdit_p3Attorney_Fax->setText(str309);
    ui->lineEdit_p3Attorney_Email->setText(str310);
    ui->lineEdit_c1Attorney_FirstName->setText(str311);
    ui->lineEdit_c1Attorney_LastName->setText(str312);
    ui->lineEdit_c1Attorney_BarID->setText(str302);
    ui->lineEdit_c1Attorney_FirmName->setText(str313);
    ui->lineEdit_c1Attorney_AddressStreet->setText(str314);
    ui->lineEdit_c1Attorney_AddressCity->setText(str315);
    ui->lineEdit_c1Attorney_AddressState->setText(str316);
    ui->lineEdit_c1Attorney_AddressPostal->setText(str317);
    ui->lineEdit_c1Attorney_Phone->setText(str318);
    ui->lineEdit_c1Attorney_Fax->setText(str319);
    ui->lineEdit_c1Attorney_Email->setText(str320);

//Case Header
    ui->lineEdit_caseNumber->setText(str154);
    ui->lineEdit_fileDate->setText(str155);
    ui->lineEdit_caseStatus->setText(str156);
    ui->checkBox_p1Attorney->setChecked(p1Attorney);
    ui->checkBox_p2Attorney->setChecked(p2Attorney);

    str157 = ui->comboBox_p1Designation->currentText();
    ui->lineEdit_p1Designation->setText(str157);
    str158 = ui->comboBox_p2Designation->currentText();
    ui->lineEdit_p2Designation->setText(str158);

//get Full Names of parties
    QStringList party1;
    party1 << str100 << str101 << str102;
    QString str159 = party1.join(" ");
    QStringList party2;
    party2 << str127 << str128  << str129;
    QString str160 = party2.join(" ");

    ui->lineEdit_p1FullName->setText(str159);
    ui->lineEdit_p2FullName->setText(str160);

 //   check text
    ui->label_debug2->setText(loadfile);

// build children table
    ui->treeWidget_childrenList->setColumnCount(6);
    ui->treeWidget_childrenList->setColumnWidth(0,90);
    ui->treeWidget_childrenList->setColumnWidth(1,150);
    ui->treeWidget_childrenList->setColumnWidth(2,150);
    ui->treeWidget_childrenList->setColumnWidth(3,120);
    ui->treeWidget_childrenList->setColumnWidth(4,100);
    ui->treeWidget_childrenList->setColumnWidth(5,100);
    ui->treeWidget_childrenList->setHeaderLabels(QStringList() << "ENTITY" << "FIRST NAME" << "LAST NAME" << "RELATIONSHIP" << "DATE OF BIRTH" << "SEX");
    AddRootChildren(str170, str171, str172, str173, str174, str175);
    AddRootChildren(str176, str177, str178, str179, str180, str181);

// build other protected table
     ui->treeWidget_otherProtected->setColumnCount(6);
     ui->treeWidget_otherProtected->setColumnWidth(0,90);
     ui->treeWidget_otherProtected->setColumnWidth(1,150);
     ui->treeWidget_otherProtected->setColumnWidth(2,150);
     ui->treeWidget_otherProtected->setColumnWidth(3,120);
     ui->treeWidget_otherProtected->setColumnWidth(4,150);
     ui->treeWidget_otherProtected->setColumnWidth(5,100);
     ui->treeWidget_otherProtected->setHeaderLabels(QStringList() << "ENTITY" << "FIRST NAME" << "LAST NAME" << "RELATIONSHIP" << "IS HOUSEHOLD MEMBER" << "SEX");
     AddRootOtherProtected(str182, str183, str184, str185, str186, str187);

// build witness table
     ui->treeWidget_Witness->setColumnCount(6);
     ui->treeWidget_Witness->setColumnWidth(0,90);
     ui->treeWidget_Witness->setColumnWidth(1,150);
     ui->treeWidget_Witness->setColumnWidth(2,150);
     ui->treeWidget_Witness->setColumnWidth(3,120);
     ui->treeWidget_Witness->setColumnWidth(4,150);
     ui->treeWidget_Witness->setColumnWidth(5,120);
     ui->treeWidget_Witness->setHeaderLabels(QStringList() << "ENTITY" << "FIRST NAME" << "LAST NAME" << "DESIGNATION" << "WITNESS FOR" << "CONTACT INFO");
     AddRootWitness(str188, str189, str190, str191, str192, str193);
     AddRootWitness(str194, str195, str196, str197, str198, str199);

// build interpreter table
     ui->treeWidget_Interpreter->setColumnCount(6);
     ui->treeWidget_Interpreter->setColumnWidth(0,90);
     ui->treeWidget_Interpreter->setColumnWidth(1,150);
     ui->treeWidget_Interpreter->setColumnWidth(2,150);
     ui->treeWidget_Interpreter->setColumnWidth(3,120);
     ui->treeWidget_Interpreter->setColumnWidth(4,150);
     ui->treeWidget_Interpreter->setColumnWidth(5,120);
     ui->treeWidget_Interpreter->setHeaderLabels(QStringList() << "ENTITY" << "FIRST NAME" << "LAST NAME" << "DESIGNATION" << "INTERPRETER FOR" << "LANGUAGE");
     AddRootInterpreter(str200, str201, str202, str203, str204, str205);

// build Related Case table
     ui->treeWidget_relatedCases->setColumnCount(6);
     ui->treeWidget_relatedCases->setColumnWidth(0,120);
     ui->treeWidget_relatedCases->setColumnWidth(1,120);
     ui->treeWidget_relatedCases->setColumnWidth(2,120);
     ui->treeWidget_relatedCases->setColumnWidth(3,120);
     ui->treeWidget_relatedCases->setColumnWidth(4,120);
     ui->treeWidget_relatedCases->setColumnWidth(5,120);
     ui->treeWidget_relatedCases->setHeaderLabels(QStringList() << "CASE NUMBER" << "CASE TYPE" << "COUNTY" << "CPO/TRO" << "EXPIRE DATE" << "LEAD CASE");
     AddRootRelatedCase(str206, str207, str208, str209, str210, str211);
     AddRootRelatedCase(str212, str213, str214, str215, str216, str217);
     AddRootRelatedCase(str218, str219, str220, str221, str222, str223);

// build Case History table
     ui->treeWidget_caseHistory->setColumnCount(10);
     ui->treeWidget_caseHistory->setColumnWidth(0,90);
     ui->treeWidget_caseHistory->setColumnWidth(1,90);
     ui->treeWidget_caseHistory->setColumnWidth(2,80);
     ui->treeWidget_caseHistory->setColumnWidth(3,80);
     ui->treeWidget_caseHistory->setColumnWidth(4,80);
     ui->treeWidget_caseHistory->setColumnWidth(5,80);
     ui->treeWidget_caseHistory->setColumnWidth(6,80);
     ui->treeWidget_caseHistory->setColumnWidth(7,80);
     ui->treeWidget_caseHistory->setColumnWidth(8,100);
     ui->treeWidget_caseHistory->setColumnWidth(9,100);
     ui->treeWidget_caseHistory->setHeaderLabels(QStringList() << "DATE" << "EVENT" << "P1 PRESENT" << "P1 SWORN" << "P1 ATTY" << "P2 PRESENT" << "P2 SWORN" << "P2 ATTY"<< "ORDERS" << "MERGE CASE");
     AddRootCaseHistory(str224, str225, str226, str227, str228, str229, str230, str231, str232, str233);
     AddRootCaseHistory(str234, str235, str236, str237, str238, str239, str240, str241, str242, str243);
     AddRootCaseHistory(str244, str245, str246, str247, str248, str249, str250, str251, str252, str253);
     AddRootCaseHistory(str254, str255, str256, str257, str258, str259, str260, str261, str262, str263);
     AddRootCaseHistory(str264, str265, str266, str267, str268, str269, str270, str271, str272, str273);

//load Case Notes
     ui->lineEdit_CaseNoteUserName1->setText(str274);
     ui->lineEdit_CaseNoteUserRole1->setText(str275);
     ui->lineEdit_CaseNoteLastDate1->setText(str276);
     ui->textEdit_NoteUser1->setText(str277);
     ui->lineEdit_CaseNoteUserName2->setText(str278);
     ui->lineEdit_CaseNoteUserRole2->setText(str279);
     ui->lineEdit_CaseNoteLastDate2->setText(str280);
     ui->textEdit_NoteUser2->setText(str281);
     ui->lineEdit_CaseNoteUserName3->setText(str282);
     ui->lineEdit_CaseNoteUserRole3->setText(str283);
     ui->lineEdit_CaseNoteLastDate3->setText(str284);
     ui->textEdit_NoteUser3->setText(str285);
     ui->lineEdit_CaseNoteUserName4->setText(str286);
     ui->lineEdit_CaseNoteUserRole4->setText(str287);
     ui->lineEdit_CaseNoteLastDate4->setText(str288);
     ui->textEdit_NoteUser4->setText(str289);
}

//LOAD NO DOCKET CASE LIST
void MainWindow::LoadNoDocketList()
{
    QString dkt1;
    QString dkt2;
    QString dkt3;
    QString dkt4;
    QString dkt5;
    QString dkt6;
    QString dkt7;
    QString dkt8;
    QString dkt9;
    QString dkt10;
    QString dkt11;

    QXmlGet xmlGet;
    xmlGet.load("/users/jamesreid/faccts_cng/faccts_docket.xml");
    xmlGet.findAndDescend("faccts");
    xmlGet.findAndDescend("nodocket");
    xmlGet.find("case");
    dkt1 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt2 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt3 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt4 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt5 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt6 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt7 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt8 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt9 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt10 = xmlGet.getString();
    xmlGet.findNext("case");
    dkt11 = xmlGet.getString();
    xmlGet.rise();

    ui->listWidget_caseDocket->addItem(dkt1);
    ui->listWidget_caseDocket->addItem(dkt2);
    ui->listWidget_caseDocket->addItem(dkt3);
    ui->listWidget_caseDocket->addItem(dkt4);
    ui->listWidget_caseDocket->addItem(dkt5);
    ui->listWidget_caseDocket->addItem(dkt6);
    ui->listWidget_caseDocket->addItem(dkt7);
    ui->listWidget_caseDocket->addItem(dkt8);
    ui->listWidget_caseDocket->addItem(dkt9);
    ui->listWidget_caseDocket->addItem(dkt10);
    ui->listWidget_caseDocket->addItem(dkt11);

}


//LOAD CASE ORDER DV110
void MainWindow::LoadCaseOrdersDV110()
{  
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

    QString str35;
    QString str36;
    QString str37;
    QString str38;
    QString str39;
    QString str59;
    QString str60;
    QString str61;
    QString str62;
    QString etime;
    QString edate;
    QString str65;
    QString str66;
    QString str67;
    QString str68;
    QString str69;
    QString str70;
    QString str71;
    QString str72;
    QString str73;
    QString str74;
    QString str75;
    QString str76;
    QString str77;
    QString str78;
    QString str79;
    QString str80;
    QString str81;
    QString str82;
    QString str83;
    QString str84;
    QString str85;
    QString str86;
    QString str87;
    QString str88;
    QString str89;
    QString str90;
    QString str91;
    QString str92;
    QString str93;
    QString str94;
    QString str95;
    QString str96;
    QString str97;
    QString str98;
    QString str99;
    QString str100;
    QString str1000;
    QString str1001;
    QString str1002;
    QString str1003;
    QString str1004;
    QString str1005;
    QString str1006;
    QString str1007;
    QString str1008;
    QString str1009;
    QString str1010;
    QString str1011;
    QString str1012;
    QString str1013;
    QString str1014;
    QString str1015;
    QString str1016;
    QString str1017;
    QString str1018;
    QString str1019;
    QString str1020;
    QString str1021;
    QString str1022;
    QString str1023;
    QString str1024;
    QString str1025;
    QString str1026;
    QString str1027;
    QString str1028;
    QString str1029;
    QString str1030;
    QString str1031;

    int oa, ob, oc, od, oe, of, og, oh, oi, oj, ok, ol, om, on, op, os;

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.findAndDescend("caseorders");
    xmlGet.findAndDescend("DV110");
    xmlGet.findAndDescend("stack1");
    xmlGet.find("DV110POSProvided");
    bool DV110POSProvided = xmlGet.getBool();
    xmlGet.find("DV110POSNotP1Delivered");
    bool DV110POSNotP1Delivered = xmlGet.getBool();
    xmlGet.findAndDescend("ConductOrders");
    xmlGet.find("DV110StatusConduct");
    oa = xmlGet.getInt();
    xmlGet.find("DV110NoContact");
    bool DV110NoContact = xmlGet.getBool();
    xmlGet.find("DV110NoHarass");
    bool DV110NoHarass = xmlGet.getBool();
    xmlGet.find("DV110NoLocate");
    bool DV110NoLocate = xmlGet.getBool();
    xmlGet.find("DV110ConductException");
    bool DV110ConductException = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("StayAwayOrders");
    xmlGet.find("DV110StatusStayAway");
    ob = xmlGet.getInt();
    xmlGet.find("DV110StayAwayDistance");
    str35 = xmlGet.getString();
    xmlGet.find("DV110NoPerson");
    bool DV110NoPerson = xmlGet.getBool();
    xmlGet.find("DV110NoWork");
    bool DV110NoWork = xmlGet.getBool();
    xmlGet.find("DV110NoSchool");
    bool DV110NoSchool = xmlGet.getBool();
    xmlGet.find("DV110NoHome");
    bool DV110NoHome = xmlGet.getBool();
    xmlGet.find("DV110NoChildcare");
    bool DV110NoChildcare = xmlGet.getBool();
    xmlGet.find("DV110NoVehicle");
    bool DV110NoVehicle = xmlGet.getBool();
    xmlGet.find("DV110StayAwayOtherOrders");
    bool DV110StayAwayOtherOrders = xmlGet.getBool();
    xmlGet.find("DV110StayAwayOtherDetail");
    str39 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("MoveOutOrders");
    xmlGet.find("DV110StatusMoveOut");
    oc  = xmlGet.getInt();
    xmlGet.find("DV110MoveOutAddress");
    str59 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("CommunicationsOrders");
    xmlGet.find("DV110StatusCommunications");
    od = xmlGet.getInt();
    xmlGet.rise();
    xmlGet.findAndDescend("AnimalsOrders");
    xmlGet.find("DV110StatusAnimals");
    oe = xmlGet.getInt();
    xmlGet.find("DV110AnimalDistance");
    str60 = xmlGet.getString();
    xmlGet.find("DV110AnimalDetail");
    str61 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("FireArmsOrders");
    xmlGet.find("DV110FireArms");
    bool DV110FireArms = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherOrders");
    xmlGet.find("DV110OtherStatusOrders");
    of = xmlGet.getInt();
    xmlGet.find("DV110OtherOrdersDetail");
    str62 = xmlGet.getString();
    xmlGet.find("DV110Expiration");
    bool DV110Expiration = xmlGet.getBool();
    xmlGet.find("DV110ExpirationTime");
    etime = xmlGet.getString();
    xmlGet.find("DV110ExpirationDate");
    edate = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("DV110OtherProtected");
    xmlGet.findAndDescend("OtherProtected1");
    xmlGet.find("entity");
    str65 = xmlGet.getString();
    xmlGet.find("fullname");
    str66 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherProtected2");
    xmlGet.find("entity");
    str67 = xmlGet.getString();
    xmlGet.find("fullname");
    str68 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
//STACK 2
    xmlGet.findAndDescend("stack2");
    xmlGet.find("orderPropertyControl");
    og = xmlGet.getInt();
    xmlGet.findAndDescend("property");
    xmlGet.findAndDescend("item1");
    xmlGet.find("propertyItem");
    str69 = xmlGet.getString();
    xmlGet.find("propertyDescription");
    str70 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("item2");
    xmlGet.find("propertyItem");
    str71  = xmlGet.getString();
    xmlGet.find("propertyDescription");
    str72 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("orderDebtPayments");
    oh = xmlGet.getInt();
    xmlGet.findAndDescend("payments");
    xmlGet.findAndDescend("debt1");
    xmlGet.find("debtItem");
    str73 = xmlGet.getString();
    xmlGet.find("paymentTo");
    str74 = xmlGet.getString();
    xmlGet.find("paymentFor");
    str75 = xmlGet.getString();
    xmlGet.find("paymentFrom");
    str76 = xmlGet.getString();
    xmlGet.find("date");
    str77 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("debt2");
    xmlGet.findNext("debtItem");
    str78 = xmlGet.getString();
    xmlGet.findNext("paymentTo");
    str79 = xmlGet.getString();
    xmlGet.findNext("paymentFor");
    str80 = xmlGet.getString();
    xmlGet.findNext("paymentFrom");
    str81 = xmlGet.getString();
    xmlGet.findNext("date");
    str82 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("orderPropertyRestraint");
    oi = xmlGet.getInt();
    xmlGet.find("p1PropertyRestraint");
    bool p1PropertyRestraint = xmlGet.getBool();
    xmlGet.find("p2PropertyRestraint");
    bool p2PropertyRestraint = xmlGet.getBool();
    xmlGet.find("otherPropertyOrders");
    oj = xmlGet.getInt();
    xmlGet.find("otherPropertyOrdersDetail");
    str83 = xmlGet.getString();
    xmlGet.rise();
// DV110 CHILDREN
    xmlGet.findAndDescend("stack3");
    xmlGet.findAndDescend("children");
    xmlGet.findAndDescend("child1");
    xmlGet.find("entity");
    str84 = xmlGet.getString();
    xmlGet.find("firstname");
    str85 = xmlGet.getString();
    xmlGet.find("lastname");
    str86 = xmlGet.getString();
    xmlGet.find("dateofbirth");
    str87 = xmlGet.getString();
    xmlGet.find("legalcustody");
    str88 = xmlGet.getString();
    xmlGet.find("physicalcustody");
    str89 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("child2");
    xmlGet.find("entity");
    str90 = xmlGet.getString();
    xmlGet.find("firstname");
    str91 = xmlGet.getString();
    xmlGet.find("lastname");
    str92 = xmlGet.getString();
    xmlGet.find("dateofbirth");
    str93 = xmlGet.getString();
    xmlGet.find("legalcustody");
    str94 = xmlGet.getString();
    xmlGet.find("physicalcustody");
    str95 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("orderStatusChildVisitation");
    ok = xmlGet.getInt();
    xmlGet.find("orderNoVisitionChildren");
    bool orderNoVisitionChildren = xmlGet.getBool();
    xmlGet.find("orderNoVisitChild");
    ol = xmlGet.getInt();
    xmlGet.find("DV110OtherParentNoVisit");
    str100 = xmlGet.getString();
    xmlGet.find("DV110VisitationMediation");
    bool DV110VisitationMediation = xmlGet.getBool();
    xmlGet.find("DV110VisitationMediationProvider");
    str96 = xmlGet.getString();
    xmlGet.find("DV110VisitationAttachment");
    bool DV110VisitationAttachment = xmlGet.getBool();
    xmlGet.find("DV110VisitationAttachmentPages");
    str97 = xmlGet.getString();
    xmlGet.find("DV110VisitationAttachmentDate");
    str98 = xmlGet.getString();
    xmlGet.find("DV110VisitationGrantedTo");
    bool ccVisitationGrantedTo = xmlGet.getBool();
    xmlGet.find("DV110VisitationParent");
    om = xmlGet.getInt();
    xmlGet.find("DV110VisitationOtherParent");
    str99 = xmlGet.getString();
    xmlGet.find("DV110ScheduleWeekends");
    bool DV110ScheduleWeekends = xmlGet.getBool();
    xmlGet.find("DV110ScheduleWeekendStartDay");
    str36 = xmlGet.getString();
    xmlGet.find("DV110ScheduleWeekendEndDay");
    str37 = xmlGet.getString();
    xmlGet.find("DV110ScheduleWeekendMonth1");
    bool DV110ScheduleWeekendMonth1 = xmlGet.getBool();
    xmlGet.find("DV110ScheduleWeekendMonth2");
    bool DV110ScheduleWeekendMonth2 = xmlGet.getBool();
    xmlGet.find("DV110ScheduleWeekendMonth3");
    bool DV110ScheduleWeekendMonth3 = xmlGet.getBool();
    xmlGet.find("DV110ScheduleWeekendMonth4");
    bool DV110ScheduleWeekendMonth4 = xmlGet.getBool();
    xmlGet.find("DV110ScheduleWeekendMonth5");
    bool DV110ScheduleWeekendMonth5 = xmlGet.getBool();
    xmlGet.find("DV110ScheduleWeekdays");
    bool DV110ScheduleWeekdays = xmlGet.getBool();
    xmlGet.find("DV110ExchangeRemove");
    bool DV110ExchangeRemove = xmlGet.getBool();
    xmlGet.find("DV110TransportFromParty");
    on = xmlGet.getInt();
    xmlGet.find("DV110TransportFromPartyOther");
    str1000 = xmlGet.getString();
    xmlGet.find("DV110TransportFromLocation");
    str1001 = xmlGet.getString();
    xmlGet.find("DV110TransportToParty");
    op = xmlGet.getInt();
    xmlGet.find("DV110TransportToPartyOther");
    str1002 = xmlGet.getString();
    xmlGet.find("DV110TransportToLocation");
    str1003 = xmlGet.getString();
//TRAVEL RESTTRICT
    xmlGet.find("DV110TravelRestrictProtected");
    bool DV110TravelRestrictProtected = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictRestrained");
    bool DV110TravelRestrictRestrained = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictOther");
    bool DV110TravelRestrictOther = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictOtherName");
    str1004 = xmlGet.getString();
    xmlGet.find("DV110TravelRestrictCA");
    bool DV110TravelRestrictCA = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictUSA");
    bool DV110TravelRestrictUSA = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictOtherPlace");
    bool DV110TravelRestrictOtherPlace = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictOtherDetail");
    str1005 = xmlGet.getString();
    xmlGet.find("DV110HabitualResidencyUS");
    bool DV110HabitualResidencyUS = xmlGet.getBool();
    xmlGet.find("DV110HabitualResidencyOther");
    bool DV110HabitualResidencyOther = xmlGet.getBool();
    xmlGet.find("DV110HabitualResidencyOtherDetail");
    str1006 = xmlGet.getString();
    xmlGet.find("DV110ChildAbductionRisk");
    bool DV110ChildAbductionRisk = xmlGet.getBool();
    xmlGet.find("DV110ChildCustodyOrders");
    str1007 = xmlGet.getString();
    xmlGet.rise();
//SUPERVISION
    xmlGet.findAndDescend("stack4");
    xmlGet.find("DV110SupervisionMediation");
    bool DV110SupervisionMediation = xmlGet.getBool();
    xmlGet.find("DV110SupervisionMediationLocation");
    str1008 = xmlGet.getString();
    xmlGet.find("DV110VisitationSupervised");
    bool DV110VisitationSupervised = xmlGet.getBool();
    xmlGet.find("DV110ExchangesSupervised");
    bool DV110ExchangesSupervised = xmlGet.getBool();
    xmlGet.find("DV110PersonSupervision");
    os = xmlGet.getInt();
    xmlGet.find("DV110PersonSupervisionOtherDetail");
    str1009 = xmlGet.getString();
    xmlGet.find("DV110SupervisionAllVisits");
    bool DV110SupervisionAllVisits = xmlGet.getBool();
    xmlGet.find("DV110SupervisionVisitsWeek");
    str1010 = xmlGet.getString();
    xmlGet.find("DV110SupervisionHoursVisit");
    str1011 = xmlGet.getString();
    xmlGet.find("DV110SupervisionOtherSchedule");
    bool DV110SupervisionOtherSchedule = xmlGet.getBool();
    xmlGet.find("DV110SupervisionOtherScheduleDetail");
    str1012 = xmlGet.getString();
    xmlGet.find("DV110SupervisionProfessional");
    bool DV110SupervisionProfessional = xmlGet.getBool();
    xmlGet.find("DV110SupervisionNonProfessional");
    bool DV110SupervisionNonProfessional = xmlGet.getBool();
    xmlGet.find("DV110SupervisionTherapeutic");
    bool DV110SupervisionTherapeutic = xmlGet.getBool();
    xmlGet.find("DV110SupervisionMomPays");
    bool DV110SupervisionMomPays  = xmlGet.getBool();
    xmlGet.find("DV110SupervisionMomPays");
    bool DV110SupervisionDadPays = xmlGet.getBool();
    xmlGet.find("DV110SupervisionOtherPays");
    bool DV110SupervisionOtherPays = xmlGet.getBool();
    xmlGet.find("DV110SupervisionMomPaysAmount");
    str1013 = xmlGet.getString();
    xmlGet.find("DV110SupervisionDadPaysAmount");
    str1014 = xmlGet.getString();
    xmlGet.find("DV110SupervisionOtherPaysAmount");
    str1015 = xmlGet.getString();
    xmlGet.find("DV110SupervisionMomContactBefore");
    bool DV110SupervisionMomContactBefore = xmlGet.getBool();
    xmlGet.find("DV110SupervisionDadContactBefore");
    bool DV110SupervisionDadContactBefore = xmlGet.getBool();
    xmlGet.find("DV110SupervisionOtherContactBefore");
    bool DV110SupervisionOtherContactBefore = xmlGet.getBool();
    xmlGet.find("DV110SupervisionOtherPaysName");
    str38 = xmlGet.getString();
    xmlGet.find("DV110SupervisionProviderName");
    str1016 = xmlGet.getString();
    xmlGet.find("DV110SupervisionProviderAddress");
    str1017 = xmlGet.getString();
    xmlGet.find("DV110SupervisionProviderPhone");
    str1018 = xmlGet.getString();
    xmlGet.find("DV110SupervisionOtherDetail");
    str1019 = xmlGet.getString();
    xmlGet.rise();
//STACK 5
    xmlGet.findAndDescend("stack5");
    xmlGet.find("DV110TravelRestrictParty");
    str1020 = xmlGet.getString();
    xmlGet.find("DV110TravelRestrictROViolation");
    bool DV110TravelRestrictROViolation = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictOutsideCA");
    bool DV110TravelRestrictOutsideCA = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictAction");
    bool DV110TravelRestrictAction = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictQuitJob");
    bool DV110TravelRestrictQuitJob = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictSoldHome");
    bool DV110TravelRestrictSoldHome = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictClosedBank");
    bool DV110TravelRestrictClosedBank = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictEndLease");
    bool DV110TravelRestrictEndLease = xmlGet.getBool();
    xmlGet.find("DDV110TravelRestrictSoldAssets");
    bool DV110TravelRestrictSoldAssets = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictDestroyDocuments");
    bool DV110TravelRestrictDestroyDocuments = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictApplyPassport");
    bool DV110TravelRestrictApplyPassport = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictPriorHistory");
    bool DV110TravelRestrictPriorHistory = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictDomesticViolence");
    bool DV110TravelRestrictDomesticViolence = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictChildAbuse");
    bool DV110TravelRestrictChildAbuse = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictNoCoopParent");
    bool DV110TravelRestrictNoCoopParent = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictCrimeRecord");
    bool DV110TravelRestrictCrimeRecord = xmlGet.getBool();
    xmlGet.find("DV110TravelRestrictForiegnTies");
    bool DV110TravelRestrictForiegnTies = xmlGet.getBool();
    xmlGet.find("DV110PostBond");
    bool DV110PostBond = xmlGet.getBool();
    xmlGet.find("DV110PostBondAmount");
    str1021 = xmlGet.getString();
    xmlGet.find("DV110NoMoveChildren");
    bool DV110NoMoveChildren = xmlGet.getBool();
    xmlGet.find("DV110NoMoveChildrenCounty");
    bool DV110NoMoveChildrenCounty = xmlGet.getBool();
    xmlGet.find("DV110NoMoveChildrenState");
    bool DV110NoMoveChildrenState = xmlGet.getBool();
    xmlGet.find("DV110NoMoveChildrenUSA");
    bool DV110NoMoveChildrenUSA = xmlGet.getBool();
    xmlGet.find("DV110NoMoveChildrenOther");
    bool DV110NoMoveChildrenOther = xmlGet.getBool();
    xmlGet.find("DV110NoMoveChildrenOtherDetail");
    str1022 = xmlGet.getString();
    xmlGet.find("DV110NoTravelChildren");
    bool DV110NoTravelChildren = xmlGet.getBool();
    xmlGet.find("DV110NoTravelChildrenCounty");
    bool DV110NoTravelChildrenCounty = xmlGet.getBool();
    xmlGet.find("DV110NoTravelChildrenState");
    bool DV110NoTravelChildrenState = xmlGet.getBool();
    xmlGet.find("DV110NoTravelChildrenUSA");
    bool DV110NoTravelChildrenUSA = xmlGet.getBool();
    xmlGet.find("DV110NoTravelChildrenOther");
    bool DV110NoTravelChildrenOther = xmlGet.getBool();
    xmlGet.find("DV110NoTravelChildrenOtherDetail");
    str1023 = xmlGet.getString();
    xmlGet.find("DV110TravelNotifyOtherState");
    bool DV110TravelNotifyOtherState = xmlGet.getBool();
    xmlGet.find("DV110TravelPermissionFromParent");
    str1031 = xmlGet.getString();
    xmlGet.find("DV110TravelNotifyOtherStateDetail");
    str1024 = xmlGet.getString();
    xmlGet.find("DV110DocumentSurrender");
    bool DV110DocumentSurrender = xmlGet.getBool();
    xmlGet.find("DV110SurrenderTravelDoc");
    str1025 = xmlGet.getString();
    xmlGet.find("DV110TravelProvideOrder");
    bool DV110TravelProvideOrder = xmlGet.getBool();
    xmlGet.find("DV110TravelProvideChildItinerary");
    bool DV110TravelProvideChildItinerary = xmlGet.getBool();
    xmlGet.find("DV110TravelProvideAirplaneTickets");
    bool DV110TravelProvideAirplaneTickets = xmlGet.getBool();
    xmlGet.find("DV110TravelProvideAddressPhone");
    bool DV110TravelProvideAddressPhone = xmlGet.getBool();
    xmlGet.find("DV110TravelProvideOtherParentTicket");
    bool DV110TravelProvideOtherParentTicket = xmlGet.getBool();
    xmlGet.find("DV110TravelProvideOther");
    bool DV110TravelProvideOther = xmlGet.getBool();
    xmlGet.find("DV110TravelProvideOtherDetail");
    str1026 = xmlGet.getString();
    xmlGet.find("DV110TravelNotifyForiegnEmbassy");
    bool DV110TravelNotifyForiegnEmbassy = xmlGet.getBool();
    xmlGet.find("DV110TravelNotifyForiegnEmbassyDetail");
    str1028 = xmlGet.getString();
    xmlGet.find("DV110TravelNotifyForiegnDays");
    str1029 = xmlGet.getString();
    xmlGet.find("DV110TravelForiegnCustodyOrder");
    bool DV110TravelForiegnCustodyOrder = xmlGet.getBool();
    xmlGet.find("DV110TravelEnforcingCourtOrder");
    bool DV110TravelEnforcingCourtOrder = xmlGet.getBool();
    xmlGet.find("DV110TravelEnforcingAgencyName");
    str1030 = xmlGet.getString();
    xmlGet.find("DV110OtherTravelRestrictionOrder");
    bool DV110OtherTravelRestrictionOrder = xmlGet.getBool();
    xmlGet.find("DV110OtherTravelOrdersDetail");
    str1027 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();

//DV110 Stack 1
    ui->radioButton_DV110POSProvided->setChecked(DV110POSProvided);
    ui->radioButton_DV110POSNotP1Delivered->setChecked(DV110POSNotP1Delivered);

    ui->comboBox_orderConduct->setCurrentIndex(oa);
    ui->checkBox_DV110NoContact->setChecked(DV110NoContact);
    ui->checkBox_DV110NoHarass->setChecked(DV110NoHarass);
    ui->checkBox_DV110NoLocate->setChecked(DV110NoLocate);
    ui->checkBox_DV110ConductException->setChecked(DV110ConductException);

    ui->comboBox_orderStayAway->setCurrentIndex(ob);
    ui->lineEdit_DV110StayAwayDistance->setText(str35);
    ui->checkBox_DV110NoPerson->setChecked(DV110NoPerson);
    ui->checkBox_DV110NoWork->setChecked(DV110NoWork);
    ui->checkBox_DV110NoSchool->setChecked(DV110NoSchool);
    ui->checkBox_DV110NoHome->setChecked(DV110NoHome);
    ui->checkBox_DV110NoChildCare->setChecked(DV110NoChildcare);
    ui->checkBox_DV110NoVehicle->setChecked(DV110NoVehicle);
    ui->checkBox_DV110StayAwayOtherOrders->setChecked(DV110StayAwayOtherOrders);
    ui->textEdit_DV110StayawayOtherDetail->setText(str39);

    ui->comboBox_orderMoveOut->setCurrentIndex(oc);
    ui->lineEdit_MoveOutAddress->setText(str59);
    ui->comboBox_orderCommunications->setCurrentIndex(od);
    ui->comboBox_orderAnimals->setCurrentIndex(oe);
    ui->lineEdit_AnimalDistance->setText(str60);
    ui->lineEdit_AnimalDetail->setText(str61);
    ui->comboBox_orderOther->setCurrentIndex(of);
    ui->textEdit_DV110OtherOrders->setText(str62);
    ui->checkBox_orderFireArm->setChecked(DV110FireArms);
    ui->checkBox_DV110Expire->setChecked(DV110Expiration);
    QTime xtime = QTime::fromString(etime,"hh:mm:ss");
    ui->timeEdit_DV110TimeExpire->setTime(xtime);
    QDate xdate = QDate::fromString(edate,"MM-dd-yyyy");
    ui->dateEdit_DV110DateExpire->setDisplayFormat("MMM-dd-yyyy");
    ui->dateEdit_DV110DateExpire->setDate(xdate);
//DV110 Stack2
    ui->comboBox_DV110PropertyControl->setCurrentIndex(og);
    ui->comboBox_DV110DebtPayments->setCurrentIndex(oh);
    ui->comboBox_DV110PropertyRestraint->setCurrentIndex(oi);
    ui->checkBox_p1PropertyRestraint->setChecked(p1PropertyRestraint);
    ui->checkBox_p2PropertyRestraint->setChecked(p2PropertyRestraint);

    ui->comboBox_DV110OtherPropertyOrders->setCurrentIndex(oj);
    ui->textEdit_DV110OtherPropertyOrders->setText(str83);
//DV110 Stack3
    ui->comboBox_DV110VisitionOrders->setCurrentIndex(ok);
    ui->checkBox_noVisitationFor->setChecked(orderNoVisitionChildren);
    ui->comboBox_noVisitationChild->setCurrentIndex(ol);
    ui->lineEdit_DV110OtherParentNoVisit->setText(str100);
    ui->checkBox_mediationProvider->setChecked(DV110VisitationMediation);
    ui->lineEdit_mediationProvider->setText(str96);
    ui->checkBox_cvOrderAttachment->setChecked(DV110VisitationAttachment);
    ui->lineEdit_cvAttachmentPages->setText(str97);
    ui->lineEdit_cvAttachmentDate->setText(str98);
    ui->checkBox_DV110VisitationGrantedTo->setChecked(ccVisitationGrantedTo);
    ui->comboBox_DV110VisitationParent->setCurrentIndex(om);
    ui->lineEdit_DV110VisitationOtherParent->setText(str99);
    ui->checkBox_DV110ScheduleWeekends->setChecked(DV110ScheduleWeekends);
    ui->checkBox_DV110ScheduleWeekendMonth1->setChecked(DV110ScheduleWeekendMonth1);
    ui->checkBox_DV110ScheduleWeekendMonth2->setChecked(DV110ScheduleWeekendMonth2);
    ui->checkBox_DV110ScheduleWeekendMonth3->setChecked(DV110ScheduleWeekendMonth3);
    ui->checkBox_DV110ScheduleWeekendMonth4->setChecked(DV110ScheduleWeekendMonth4);
    ui->checkBox_DV110ScheduleWeekendMonth5->setChecked(DV110ScheduleWeekendMonth5);
    ui->lineEdit_DV110ScheduleWeekendStartDay->setText(str36);
    ui->lineEdit_DV110ScheduleWeekendEndDay->setText(str37);
    ui->checkBox_DV110ScheduleWeekdays->setChecked(DV110ScheduleWeekdays);
    ui->checkBox_DV110ExchangeRemove->setChecked(DV110ExchangeRemove);
    ui->comboBox_DV110TransportFromParty->setCurrentIndex(on);
    ui->lineEdit_DV110TransportFromPartyOther->setText(str1000);
    ui->lineEdit_DV110TransportFromLocation->setText(str1001);
    ui->comboBox_DV110TransportToParty->setCurrentIndex(op);
    ui->lineEdit_DV110TransportToPartyOther->setText(str1002);
    ui->lineEdit_DV110TransportToLocation->setText(str1003);
    ui->checkBox_DV110TravelRestrictProtected->setChecked(DV110TravelRestrictProtected);
    ui->checkBox_DV110TravelRestrictRestrained->setChecked(DV110TravelRestrictRestrained);
    ui->checkBox_DV110TravelRestrictOther->setChecked(DV110TravelRestrictOther);
    ui->lineEdit_DV110TravelRestrictOtherName->setText(str1004);
    ui->checkBox_DV110TravelRestrictCA->setChecked(DV110TravelRestrictCA);
    ui->checkBox_DV110TravelRestrictUSA->setChecked(DV110TravelRestrictUSA);
    ui->checkBox_DV110TravelRestrictOtherPlace->setChecked(DV110TravelRestrictOtherPlace);
    ui->lineEdit_DV110TravelRestrictOtherDetail->setText(str1005);
    ui->checkBox_DV110HabitualResidencyUS->setChecked(DV110HabitualResidencyUS);
    ui->checkBox_DV110HabitualResidencyOther->setChecked(DV110HabitualResidencyOther);
    ui->lineEdit_DV110HabitualResidencyOtherDetail->setText(str1006);
    ui->checkBox_DV110ChildAbductionRisk->setChecked(DV110ChildAbductionRisk);
    ui->textEdit_DV110ChildCustodyOrders->setText(str1007);
//DV110 Stack4
    ui->checkBox_DV110SupervisionMediation->setChecked(DV110SupervisionMediation);
    ui->lineEdit_DV110SupervisionMediation->setText(str1008);
    ui->checkBox_DV110SupervisionVisitation->setChecked(DV110VisitationSupervised);
    ui->checkBox_DV110SupervisionExchange->setChecked(DV110ExchangesSupervised);
    ui->comboBox_DV110SupervisionParty->setCurrentIndex(os);
    ui->lineEdit_DV110SupervisionPartyOther->setText(str1009);
    ui->checkBox_DV110SupervisionVisitsAll->setChecked(DV110SupervisionAllVisits);
    ui->lineEdit_DV110SupervisionVisitWeek->setText(str1010);
    ui->lineEdit_DV110SupervisionHoursVisit->setText(str1011);
    ui->checkBox_DV110SupervisionVisitsOther->setChecked(DV110SupervisionOtherSchedule);
    ui->textEdit_DV110SupervisionScheduleOther->setText(str1012);
    ui->radioButton_DV110SupervisionProfessional->setChecked(DV110SupervisionProfessional);
    ui->radioButton_DV110SupervisionNonProfessional->setChecked(DV110SupervisionNonProfessional);
    ui->radioButton_DV110SupervisionTherapeutic->setChecked(DV110SupervisionTherapeutic);
    ui->checkBox_DV110SupervisionMomPays->setChecked(DV110SupervisionMomPays);
    ui->checkBox_DV110SupervisionDadPays->setChecked(DV110SupervisionDadPays);
    ui->checkBox_DV110SupervisionOtherPays->setChecked(DV110SupervisionOtherPays);
    ui->lineEdit_DV110SupervisionMomPays->setText(str1013);
    ui->lineEdit_DV110SupervisionDadPays->setText(str1014);
    ui->lineEdit_DV110SupervisionOtherPays->setText(str1015);
    ui->lineEdit_DV110SupervisionOtherPaysName->setText(str38);
    ui->checkBox_DV110SupervisionMomContactBefore->setChecked(DV110SupervisionMomContactBefore);
    ui->checkBox_DV110SupervisionDadContactBefore->setChecked(DV110SupervisionDadContactBefore);
    ui->checkBox_DV110SupervisionOtherContactBefore->setChecked(DV110SupervisionOtherContactBefore);
    ui->lineEdit_DV110SupervisionProviderName->setText(str1016);
    ui->lineEdit_DV110SupervisionProviderAddress->setText(str1017);
    ui->lineEdit_DV110SupervisionProviderPhone->setText(str1018);
    ui->textEdit_DV110SupervisionOtherOrders->setText(str1019);

//DV110 Stack5
    ui->lineEdit_DV110TravelRestrictParty->setText(str1020);
    ui->checkBox_DV110TravelRestrictROViolation->setChecked(DV110TravelRestrictROViolation);
    ui->checkBox_DV110TravelRestrictNoTiesCalifornia->setChecked(DV110TravelRestrictOutsideCA);
    ui->checkBox_DV110TravelRestrictionQuitJob->setChecked(DV110TravelRestrictAction);
    ui->checkBox_DV110TravelRestrictFindingsDetail->setChecked(DV110TravelRestrictQuitJob);
    ui->checkBox_DV110TravelRestrictSoldHome->setChecked(DV110TravelRestrictSoldHome);
    ui->checkBox_DV110TravelRestrictBankAccount->setChecked(DV110TravelRestrictClosedBank);
    ui->checkBox_DV110TravelRestrictEndLease->setChecked(DV110TravelRestrictEndLease);
    ui->checkBox_DV110TravelRestrictSoldAssets->setChecked(DV110TravelRestrictSoldAssets);
    ui->checkBox_DV110TravelRestrictHideDocuments->setChecked(DV110TravelRestrictDestroyDocuments);
    ui->checkBox_DV110TravelRestrictAppliedPassport->setChecked(DV110TravelRestrictApplyPassport);
    ui->checkBox_DV110TravelRestrictPriorHistory->setChecked(DV110TravelRestrictPriorHistory);
    ui->checkBox_DV110TravelRestrictDomesticViolence->setChecked(DV110TravelRestrictDomesticViolence);
    ui->checkBox_DV110TravelRestrictChildAbuse->setChecked(DV110TravelRestrictChildAbuse);
    ui->checkBox_DV110TravelRestrictNonParenting->setChecked(DV110TravelRestrictNoCoopParent);
    ui->checkBox_DV110TravelRestrictCriminalRecord->setChecked(DV110TravelRestrictCrimeRecord);
    ui->checkBox_DV110TravelRestrictForiegnTies->setChecked(DV110TravelRestrictForiegnTies);
    ui->checkBox_DV110TravelRestrictPostBond->setChecked(DV110PostBond);
    ui->lineEdit_DV110TravelRestrictPostBondAmount->setText(str1021);
    ui->checkBox_DV110NoMoveChildren->setChecked(DV110NoMoveChildren);
    ui->checkBox_DV110NoMoveCounty->setChecked(DV110NoMoveChildrenCounty);
    ui->checkBox_DV110NoMoveCalifornia->setChecked(DV110NoMoveChildrenState);
    ui->checkBox_DV110NoMoveUSA->setChecked(DV110NoMoveChildrenUSA);
    ui->checkBox_DV110NoMoveOther ->setChecked(DV110NoMoveChildrenOther);
    ui->lineEdit_DV110NoMoveOtherDetail->setText(str1022);
    ui->checkBox_DV110NoTravelChildren->setChecked(DV110NoTravelChildren);
    ui->checkBox_DV110NoTravelCounty->setChecked(DV110NoTravelChildrenCounty);
    ui->checkBox_DV110NoTravelCalifornia->setChecked(DV110NoTravelChildrenState);
    ui->checkBox_DV110NoTravelUSA->setChecked(DV110NoTravelChildrenUSA);
    ui->checkBox_DV110NoTravelOther->setChecked(DV110NoTravelChildrenOther);
    ui->lineEdit_DV110NoTravelOtherDetail->setText(str1023);
    ui->checkBox_DV110NotifyOtherState->setChecked(DV110TravelNotifyOtherState);
    ui->lineEdit_DV110NotifyOtherStateDetail->setText(str1024);
    ui->lineEdit_DV110TravelPermissionFromParent->setText(str1031);
    ui->checkBox_DV110DocumentSurrender->setChecked(DV110DocumentSurrender);
    ui->lineEdit_DV110SurrenderTravelDoc->setText(str1025);
    ui->checkBox_DV110TravelProvideOrder->setChecked(DV110TravelProvideOrder);
    ui->checkBox_DV110TravelProvideChildItinerary->setChecked(DV110TravelProvideChildItinerary);
    ui->checkBox_DV110TravelProvideAirplaneTicket->setChecked(DV110TravelProvideAirplaneTickets);
    ui->checkBox_DV110TravelProvideAddressPhone->setChecked(DV110TravelProvideAddressPhone);
    ui->checkBox_DV110TravelProvideOtherParentTicket->setChecked(DV110TravelProvideOtherParentTicket);
    ui->checkBox_DV110TravelProvideOther->setChecked(DV110TravelProvideOther);
    ui->lineEdit_DV110TravelProvideOtherDetail->setText(str1026);

    ui->checkBox_DV110TravelNotifyForiegnEmbassy->setChecked(DV110TravelNotifyForiegnEmbassy);
    ui->lineEdit_DV110TravelNotifyForiegnEmbassyDetail->setText(str1028);
    ui->lineEdit_DV110TravelNotifyForiegnEmbassyDays->setText(str1029);
    ui->checkBox_DV110TravelForiegnCustodyOrder->setChecked(DV110TravelForiegnCustodyOrder);
    ui->checkBox_DV110TravelEnforcingCourtOrder->setChecked(DV110TravelEnforcingCourtOrder);

    ui->checkBox_DV110OtherTravelRestrictionOrder->setChecked(DV110OtherTravelRestrictionOrder);
    ui->textEdit_DV110OtherTravelRestrictionOrders->setText(str1027);
//Other Protected Table
    ui->treeWidget_DV110OthersProtected->setColumnCount(2);
    ui->treeWidget_DV110OthersProtected->setColumnWidth(0,90);
    ui->treeWidget_DV110OthersProtected->setColumnWidth(1,120);
    ui->treeWidget_DV110OthersProtected->setHeaderLabels(QStringList() << "ENTITY" << "FULL NAME");
    AddRootChildrenOrder(str65, str66);
    AddRootChildrenOrder(str67, str68);

//Property Control Table
    ui->treeWidget_DV110PropertyControl->setColumnCount(2);
    ui->treeWidget_DV110PropertyControl->setColumnWidth(0,150);
    ui->treeWidget_DV110PropertyControl->setColumnWidth(1,400);
    ui->treeWidget_DV110PropertyControl->setHeaderLabels(QStringList() << "PROPERTY ITEM" << "PROPERTY DESCRIPTION");
    AddRootPropertyControl(str69, str70);
    AddRootPropertyControl(str71, str72);

//Payments Table
    ui->treeWidget_DV110Payments->setColumnCount(5);
    ui->treeWidget_DV110Payments->setColumnWidth(0,150);
    ui->treeWidget_DV110Payments->setColumnWidth(1,150);
    ui->treeWidget_DV110Payments->setColumnWidth(2,150);
    ui->treeWidget_DV110Payments->setColumnWidth(3,150);
    ui->treeWidget_DV110Payments->setColumnWidth(4,150);
    ui->treeWidget_DV110Payments->setHeaderLabels(QStringList() << "DEBT ITEM" << "PAYMENT TO" << "PAYMENT FOR" << "PAYMENT FROM" << "DATE");
    AddRootDebtPayment(str73, str74, str75, str76, str77);
    AddRootDebtPayment(str78, str79, str80, str81, str82);

//Child Custody Table
    ui->treeWidget_DV110Children->setColumnCount(6);
    ui->treeWidget_DV110Children->setColumnWidth(0,90);
    ui->treeWidget_DV110Children->setColumnWidth(1,150);
    ui->treeWidget_DV110Children->setColumnWidth(2,150);
    ui->treeWidget_DV110Children->setColumnWidth(3,120);
    ui->treeWidget_DV110Children->setColumnWidth(4,120);
    ui->treeWidget_DV110Children->setColumnWidth(4,120);
    ui->treeWidget_DV110Children->setHeaderLabels(QStringList() << "ENTITY" << "FIRST NAME" << "LAST NAME" << "DATE OF BIRTH" << "LEGAL CUSTODY" << "PHYSICAL CUSTODY");
    AddRootDV110Children(str84, str85, str86, str87, str88, str89);
    AddRootDV110Children(str90, str91, str92, str93, str94, str95);
}

// LOAD CASE ORDER DV130
void MainWindow::LoadCaseOrdersDV130()
{
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

    QString str300;
    QString str301;
    QString str302;
    QString str303;
    QString str304;
    QString expiretime;
    QString expiredate;
    QString str305;
    QString str306;
    QString str307;
    QString str308;
    QString str309;
    QString str310;
    QString str311;
    QString childfname1;
    QString childlname1;
    QString childfname2;
    QString childlname2;
    QString str316;
    QString str314;
    QString str315;
    QString str317;

    QString str320;
    QString str321;
    QString str322;
    QString str323;
    QString str324;
    QString str325;
    QString str326;
    QString weekenddate;
    QString stime1;
    QString etime1;
    QString stime2;
    QString etime2;
    QString str327;
    QString str328;
    QString str329;
    QString str330;
    QString str331;
    QString str332;
    QString str333;
    QString str334;
    QString str335;
    QString str336;
    QString str337;
    QString str338;
    QString str339;
    QString str340;
    QString str341;
    QString str342;
    QString str343;
    QString str344;
    QString str345;
    QString str346;
    QString str347;
    QString str348;
    QString contactdate1;
    QString contactdate2;
    QString str349;
    QString str350;
    QString str351;
    QString str352;
    QString str353;
    QString str354;
    QString str355;
    QString str356;
    QString str357;
    QString str358;
    QString str359;

    QString str360;
    QString str361;
    QString str362;
    QString str363;
    QString str364;
    QString str365;
    QString str366;
    QString str367;
    QString str368;
    QString str369;
    QString str370;
    QString str371;
    QString str372;
    QString str373;
    QString str374;
    QString str375;
    QString str376;
    QString str377;
    QString str378;
    QString str379;
    QString str380;
    QString str381;
    QString csstartdate;
    QString str382;
    QString str383;
    QString str384;
    QString str385;
    QString str386;
    QString str387;
    QString str388;
    QString str389;
    QString str390;
    QString str391;
    QString str392;
    QString judgedate;
    QString str394;
    QString str395;
    QString str396;
    QString str397;
    QString str398;
    QString str399;
    QString supportstart;
    QString supportend;
    QString str1;
    QString str2;
    QString str3;
    QString str4;
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

    QString str400;
    QString str401;
    QString str402;
    QString str403;
    QString str404;
    QString str405;
    QString str406;
    QString str407;
    QString str408;
    QString str409;
    QString str410;
    QString str411;
    QString str412;
    QString str413;
    QString str414;
    QString str415;
    QString str416;
    QString str417;
    QString str418;

    int ba, bb, bc, bd, be, bf, bg, bh, bi;

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.find("caseorders");
    xmlGet.findAndDescend("DV130");
    xmlGet.findAndDescend("stack1");
    xmlGet.find("DV130POSDelivered");
    bool DV130POSDelivered = xmlGet.getBool();
    xmlGet.find("DV130POSNotDeliveredP1");
    bool DV130POSNotDeliveredP1 = xmlGet.getBool();
    xmlGet.find("DV130Conduct");
    bool DV130Conduct = xmlGet.getBool();
    xmlGet.find("DV130Contact");
    bool DV130Contact = xmlGet.getBool();
    xmlGet.find("DV130Harass");
    bool DV130Harass = xmlGet.getBool();
    xmlGet.find("DV130Locate");
    bool DV130Locate = xmlGet.getBool();
    xmlGet.find("DV130ConductException");
    bool DV130ConductException = xmlGet.getBool();
    xmlGet.find("DV130StayAway");
    bool DV130StayAway = xmlGet.getBool();
    xmlGet.find("DV130StayAwayDistance");
    str300 = xmlGet.getString();
    xmlGet.find("DV130NoPerson");
    bool DV130NoPerson = xmlGet.getBool();
    xmlGet.find("DV130NoWork");
    bool DV130NoWork = xmlGet.getBool();
    xmlGet.find("DV130NoSchool");
    bool DV130NoSchool = xmlGet.getBool();
    xmlGet.find("DV130NoHome");
    bool DV130NoHome = xmlGet.getBool();
    xmlGet.find("DV130NoChildCare");
    bool DV130NoChildCare = xmlGet.getBool();
    xmlGet.find("DV130NoVehicle");
    bool DV130NoVehicle = xmlGet.getBool();
    xmlGet.find("DV130StayAwayOther");
    bool DV130StayAwayOther = xmlGet.getBool();
    xmlGet.find("DV130StayAwayAttach");
    bool DV130StayAwayAttach = xmlGet.getBool();
    xmlGet.find("DV130StayAwayOtherDetail");
    str301 = xmlGet.getString();
    xmlGet.find("DV130MoveOut");
    bool DV130MoveOut = xmlGet.getBool();
    xmlGet.find("DV130MoveOutAddress");
    str302 = xmlGet.getString();
    xmlGet.find("DV130CommunicationsRecording");
    bool DV130CommunicationsRecording = xmlGet.getBool();
    xmlGet.find("DV130Animals");
    bool DV130Animals = xmlGet.getBool();
    xmlGet.find("DV130AnimalsDistance");
    str303 = xmlGet.getString();
    xmlGet.find("DV130AnimalsDetail");
    str304 = xmlGet.getString();
    xmlGet.find("DV130OtherOrders");
    bool DV130OtherOrders = xmlGet.getBool();
    xmlGet.find("DV130OtherOrdersDetail");
    str305 = xmlGet.getString();
    xmlGet.find("DV130BatterIntervention");
    bool DV130BatterIntervention = xmlGet.getBool();
    xmlGet.find("DV130FireArms");
    bool DV130FireArms = xmlGet.getBool();
    xmlGet.find("DV130NoExpire");
    bool DV130NoExpire = xmlGet.getBool();
    xmlGet.find("DV130Expire");
    bool DV130Expire = xmlGet.getBool();
    xmlGet.find("DV130ExpireTime");
    expiretime = xmlGet.getString();
    xmlGet.find("DV130ExpireDate");
    expiredate = xmlGet.getString();
    xmlGet.findAndDescend("otherprotected");
    xmlGet.findAndDescend("otherparty1");
    xmlGet.find("entity");
    str306 = xmlGet.getString();
    xmlGet.find("fullname");
    str307 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("otherparty2");
    xmlGet.find("entity");
    str308 = xmlGet.getString();
    xmlGet.find("fullname");
    str309 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
//Get Stack2
    xmlGet.findAndDescend("stack2");
    xmlGet.find("PropertyControl");
    bool DV130PropertyControl = xmlGet.getBool();
    xmlGet.findAndDescend("property");
    xmlGet.findAndDescend("item1");
    xmlGet.find("propertyItem");
    str400 = xmlGet.getString();
    xmlGet.find("propertyGivenTo");
    str401 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("item2");
    xmlGet.find("propertyItem");
    str402  = xmlGet.getString();
    xmlGet.find("propertyGivenTo");
    str403 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("item3");
    xmlGet.find("propertyItem");
    str404  = xmlGet.getString();
    xmlGet.find("propertyGivenTo");
    str405 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("DebtPayment");
    bool DV130DebtPayment = xmlGet.getBool();
    xmlGet.findAndDescend("payments");
    xmlGet.findAndDescend("debt1");
    xmlGet.find("debtItem");
    str406 = xmlGet.getString();
    xmlGet.find("paymentTo");
    str407 = xmlGet.getString();
    xmlGet.find("paymentFor");
    str408 = xmlGet.getString();
    xmlGet.find("paymentFrom");
    str409 = xmlGet.getString();
    xmlGet.find("date");
    str410 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("debt2");
    xmlGet.findNext("debtItem");
    str411 = xmlGet.getString();
    xmlGet.findNext("paymentTo");
    str412 = xmlGet.getString();
    xmlGet.findNext("paymentFor");
    str413 = xmlGet.getString();
    xmlGet.findNext("paymentFrom");
    str414 = xmlGet.getString();
    xmlGet.findNext("date");
    str415 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("DV130PropertyRestraint");
    bool DV130PropertyRestraint = xmlGet.getBool();
    xmlGet.find("DV130PropertyRestraintProtected");
    bool DV130PropertyRestraintProtected = xmlGet.getBool();
    xmlGet.find("DV130PropertyRestraintRestrained");
    bool DV130PropertyRestraintRestrained = xmlGet.getBool();
    xmlGet.rise();
//Get Stack3
    xmlGet.findAndDescend("stack3");
    xmlGet.findAndDescend("children");
    xmlGet.findAndDescend("child1");
    xmlGet.find("entity");
    str311 = xmlGet.getString();
    xmlGet.find("firstname");
    childfname1 = xmlGet.getString();
    xmlGet.find("lastname");
    childlname1 = xmlGet.getString();
    xmlGet.find("dateofbirth");
    str314 = xmlGet.getString();
    xmlGet.find("legalcustody");
    str315 = xmlGet.getString();
    xmlGet.find("physicalcustody");
    str316 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("child2");
    xmlGet.find("entity");
    str317 = xmlGet.getString();
    xmlGet.find("firstname");
    childfname2 = xmlGet.getString();
    xmlGet.find("lastname");
    childlname2 = xmlGet.getString();
    xmlGet.find("dateofbirth");
    str320 = xmlGet.getString();
    xmlGet.find("legalcustody");
    str321 = xmlGet.getString();
    xmlGet.find("physicalcustody");
    str322 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("DV130VisitationOrders");
    bool DV130VisitationOrders = xmlGet.getBool();
    xmlGet.find("DV130VisitationOtherParent");
    bool DV130VisitationOtherParent = xmlGet.getBool();
    xmlGet.find("DV130VisitationOtherParentName");
    str323 = xmlGet.getString();
    xmlGet.find("DV130NoVisitation");
    bool DV130NoVisitation = xmlGet.getBool();
    xmlGet.find("DV130NoVisitationParent");
    ba = xmlGet.getInt();
    xmlGet.find("DV130OtherParentNoVisit");
    str418 = xmlGet.getString();
    xmlGet.find("DV130VisitationMediation");
    bool DV130VisitationMediation = xmlGet.getBool();
    xmlGet.find("DV130VisitationMediationProvider");
    str324 = xmlGet.getString();
    xmlGet.find("DV130VisitationAttachment");
    bool DV130VisitationAttachment = xmlGet.getBool();
    xmlGet.find("DV130VisitationAttachmentPages");
    str325 = xmlGet.getString();
    xmlGet.find("DV130VisitationAttachmentDate");
    str326 = xmlGet.getString();
    xmlGet.find("DV130VisitationGrantedTo");
    bool DV130VisitationGrantedTo = xmlGet.getBool();
    xmlGet.find("DV130VisitationParent");
    bb = xmlGet.getInt();
    xmlGet.find("DV130VisitationGrantedOtherParentName");
    str327 = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekends");
    bool DV130ScheduleWeekends = xmlGet.getBool();
    xmlGet.find("DV130ScheduleWeekendsCommenceDate");
    weekenddate = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekendMonth1");
    bool DV130ScheduleWeekendMonth1 = xmlGet.getBool();
    xmlGet.find("DV130ScheduleWeekendMonth2");
    bool DV130ScheduleWeekendMonth2 = xmlGet.getBool();
    xmlGet.find("DV130ScheduleWeekendMonth3");
    bool DV130ScheduleWeekendMonth3 = xmlGet.getBool();
    xmlGet.find("DV130ScheduleWeekendMonth4");
    bool DV130ScheduleWeekendMonth4 = xmlGet.getBool();
    xmlGet.find("DV130ScheduleWeekendMonth5");
    bool DV130ScheduleWeekendMonth5 = xmlGet.getBool();
    xmlGet.find("DV130ScheduleWeekendStartDay");
    str328 = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekendEndDay");
    str329 = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekendVisitStartTime");
    stime1 = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekendVisitEndTime");
    etime1 = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekdays");
    bool DV130ScheduleWeekdays = xmlGet.getBool();
    xmlGet.find("DV130ScheduleWeekdayStartDay");
    str330 = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekdayEndDay");
    str331 = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekdayStartTime");
    stime2 = xmlGet.getString();
    xmlGet.find("DV130ScheduleWeekdayEndTime");
    etime2 = xmlGet.getString();
    xmlGet.find("DV130ScheduleVisitationOther");
    bool DV130ScheduleVisitationOther = xmlGet.getBool();
    xmlGet.find("DV130ExchangeRemove");
    bool DV130ExchangeRemove = xmlGet.getBool();
    xmlGet.find("DV130TransportOrders");
    bool DV130TransportOrders = xmlGet.getBool();
    xmlGet.find("DV130TransportFromParty");
    bc = xmlGet.getInt();
    xmlGet.find("DV130TransportFromPartyOther");
    str332 = xmlGet.getString();
    xmlGet.find("DV130TransportFromLocation");
    str333 = xmlGet.getString();
    xmlGet.find("DV130TransportToParty");
    bd = xmlGet.getInt();
    xmlGet.find("DV130TransportToPartyOther");
    str334 = xmlGet.getString();
    xmlGet.find("DV130TransportToLocation");
    str335 = xmlGet.getString();
    xmlGet.find("DV130TravelRestrictOrders");
    bool DV130TravelRestrictOrders = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictMom");
    bool DV130TravelRestrictMom = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictDad");
    bool DV130TravelRestrictDad = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictOtherParent");
    bool DV130TravelRestrictOtherParent = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictOtherParentName");
    str336 = xmlGet.getString();
    xmlGet.find("DV130TravelRestrictUSA");
    bool DV130TravelRestrictUSA = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictCA");
    bool DV130TravelRestrictCA = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictOtherLocation");
    bool DV130TravelRestrictOtherLocation = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictOtherLocationDetail");
    str337 = xmlGet.getString();
    xmlGet.find("DV130HabitualResidencyUS");
    bool DV130HabitualResidencyUS = xmlGet.getBool();
    xmlGet.find("DV130HabitualResidencyOther");
    bool DV130HabitualResidencyOther = xmlGet.getBool();
    xmlGet.find("DV130HabitualResidencyOtherDetail");
    str338 = xmlGet.getString();
    xmlGet.find("DV130ChildAbductionRisk");
    bool DV130ChildAbductionRisk = xmlGet.getBool();
    xmlGet.find("DV130AttachDV145");
    bool DV130AttachDV145 = xmlGet.getBool();
    xmlGet.find("DV130ChildCustodyOtherOrders");
    bool DV130ChildCustodyOtherOrders = xmlGet.getBool();
    xmlGet.find("DV130ChildCustodyOtherOrdersDetail");
    str339 = xmlGet.getString();
    xmlGet.rise();
//Get Stack4
    xmlGet.findAndDescend("stack4");
    xmlGet.find("DV130SupervisionMediation");
    bool DV130SupervisionMediation = xmlGet.getBool();
    xmlGet.find("DV130SupervisionMediationLocation");
    str340 = xmlGet.getString();
    xmlGet.find("DV130VisitationSupervised");
    bool DV130VisitationSupervised = xmlGet.getBool();
    xmlGet.find("DV130ExchangesSupervised");
    bool DV130ExchangesSupervised = xmlGet.getBool();
    xmlGet.find("DV130SupervisionOtherParent");
    be = xmlGet.getInt();
    xmlGet.find("DV130SupervisionOtherParentName");
    str341 = xmlGet.getString();
    xmlGet.find("DV130SupervisionAllVisits");
    bool DV130SupervisionAllVisits = xmlGet.getBool();
    xmlGet.find("DV130SupervisionVisitsWeek");
    str342 = xmlGet.getString();
    xmlGet.find("DV130SupervisionHoursVisit");
    str343 = xmlGet.getString();
    xmlGet.find("DV130SupervisionOtherSchedule");
    bool DV130SupervisionOtherSchedule = xmlGet.getBool();
    xmlGet.find("DV130SupervisionOtherScheduleDetail");
    str344 = xmlGet.getString();
    xmlGet.find("DV130SupervisionProfessional");
    bool DV130SupervisionProfessional = xmlGet.getBool();
    xmlGet.find("DV130SupervisionNonProfessional");
    bool DV130SupervisionNonProfessional = xmlGet.getBool();
    xmlGet.find("DV130SupervisionTherapeutic");
    bool DV130SupervisionTherapeutic = xmlGet.getBool();
    xmlGet.find("DV130SupervisionMomPays");
    bool DV130SupervisionMomPays = xmlGet.getBool();
    xmlGet.find("DV130SupervisionDadPays");
    bool DV130SupervisionDadPays = xmlGet.getBool();
    xmlGet.find("DV130SupervisionOtherPays");
    bool DV130SupervisionOtherPays = xmlGet.getBool();
    xmlGet.find("DV130SupervisionOtherPaysName");
    str345 = xmlGet.getString();
    xmlGet.find("DV130SupervisionMomPaysAmount");
    str346 = xmlGet.getString();
    xmlGet.find("DV130SupervisionDadPaysAmount");
    str347 = xmlGet.getString();
    xmlGet.find("DV130SupervisionOtherPaysAmount");
    str348 = xmlGet.getString();
    xmlGet.find("DV130SupervisionMomContactBefore");
    bool DV130SupervisionMomContactBefore = xmlGet.getBool();
    xmlGet.find("DV130SupervisionDadContactBefore");
    bool DV130SupervisionDadContactBefore = xmlGet.getBool();
    xmlGet.find("DV130SupervisionOtherContactBefore");
    bool DV130SupervisionOtherContactBefore = xmlGet.getBool();
    xmlGet.find("DV130SupervisionMomContactDate");
    contactdate1 = xmlGet.getString();
    xmlGet.find("DV130SupervisionDadContactDate");
    contactdate2 = xmlGet.getString();
    xmlGet.find("DV130SupervisionProviderName");
    str349 = xmlGet.getString();
    xmlGet.find("DV130SupervisionProviderAddress");
    str350 = xmlGet.getString();
    xmlGet.find("DV130SupervisionProviderPhone");
    str351 = xmlGet.getString();
    xmlGet.find("DV130SupervisionOtherOrdersDetail");
    str352 = xmlGet.getString();
    xmlGet.rise();
//Get Stack5
    xmlGet.findAndDescend("stack5");
    xmlGet.find("DV130CSAttachmentFOAH");
    bool DV130CSAttachmentFOAH = xmlGet.getBool();
    xmlGet.find("DV130CSAttachmentDVRO");
    bool DV130CSAttachmentDVRO = xmlGet.getBool();
    xmlGet.find("DV130CSAttachmentJudgement");
    bool DV130CSAttachmentJudgement = xmlGet.getBool();
    xmlGet.find("DV130CSAttachmentOther");
    bool DV130CSAttachmentOther = xmlGet.getBool();
    xmlGet.find("DV130CSAttachmentOtherDetail");
    str353 = xmlGet.getString();
    xmlGet.find("DV130CSAttachmentComputerPrintOut");
    bool DV130CSAttachmentComputerPrintOut = xmlGet.getBool();
    xmlGet.find("DV130CSNonGuidelineOrder");
    bool DV130CSNonGuidelineOrder = xmlGet.getBool();
    xmlGet.findAndDescend("DV130CSChildTable");
    xmlGet.findAndDescend("DV130Child1");
    xmlGet.find("CSPaidToParent");
    str354 = xmlGet.getString();
    xmlGet.find("CSPaidAmount");
    str355 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("DV130Child2");
    xmlGet.find("CSPaidToParent");
    str356 = xmlGet.getString();
    xmlGet.find("CSPaidAmount");
    str357 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("DV130CSPaymentFirstMonth");
    bool DV130CSPaymentFirstMonth = xmlGet.getBool();
    xmlGet.find("DV130CSPaymentTwiceMonth");
    bool DV130CSPaymentTwiceMonth = xmlGet.getBool();
    xmlGet.find("DV130CSPaymentOther");
    bool DV130CSPaymentOther = xmlGet.getBool();
    xmlGet.find("DV130CSPaymentOtherDetail");
    str358 = xmlGet.getString();
    xmlGet.find("DV130CSPaymentPaidByParty");
    bf = xmlGet.getInt();
    xmlGet.find("DV130CSPaymentPayToParty");
    bg = xmlGet.getInt();
    xmlGet.find("DV130CSLowIncomeBasis");
    bool DV130CSLowIncomeBasis = xmlGet.getBool();
    xmlGet.find("DV130CSLowIncomeNotApply");
    bool DV130CSLowIncomeNotApply = xmlGet.getBool();
    xmlGet.find("DV130CSLowIncomeNotApplyDetail");
    str359 = xmlGet.getString();
    xmlGet.find("DV130CSIncomeBasis");
    bool DV130CSIncomeBasis = xmlGet.getBool();
    xmlGet.findAndDescend("DV130CSIncomeTable");
    xmlGet.findAndDescend("DV130IncomePlaintiff");
    xmlGet.find("CSRole");
    str360 = xmlGet.getString();
    xmlGet.find("CSGrossMonth");
    str361 = xmlGet.getString();
    xmlGet.find("CSNetMonth");
    str362 = xmlGet.getString();
    xmlGet.find("CSCalWorks");
    str363 = xmlGet.getString();
    xmlGet.find("CSImputedIncome");
    str364 = xmlGet.getString();
    xmlGet.find("CSImputedPerMonth");
    str365 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("DV130IncomeRespondent");
    xmlGet.find("CSRole");
    str366 = xmlGet.getString();
    xmlGet.find("CSGrossMonth");
    str367 = xmlGet.getString();
    xmlGet.find("CSNetMonth");
    str368 = xmlGet.getString();
    xmlGet.find("CSCalWorks");
    str369 = xmlGet.getString();
    xmlGet.find("CSImputedIncome");
    str370 = xmlGet.getString();
    xmlGet.find("CSImputedPerMonth");
    str371 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("DV130IncomeOtherParty");
    xmlGet.find("CSRole");
    str372 = xmlGet.getString();
    xmlGet.find("CSGrossMonth");
    str373 = xmlGet.getString();
    xmlGet.find("CSNetMonth");
    str374 = xmlGet.getString();
    xmlGet.find("CSCalWorks");
    str375 = xmlGet.getString();
    xmlGet.find("CSImputedIncome");
    str376 = xmlGet.getString();
    xmlGet.find("CSImputedPerMonth");
    str377 = xmlGet.getString(); ;
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("DV130CSTimeShareBasis");
    bool DV130CSTimeShareBasis = xmlGet.getBool();
    xmlGet.find("DV130CSTimeSharePetitioner");
    str378 = xmlGet.getString();
    xmlGet.find("DV130CSTimeShareRespondent");
    str379 = xmlGet.getString();
    xmlGet.find("DV130CSTimeShareOtherParent");
    str380 = xmlGet.getString();
    xmlGet.find("DV130CSHardshipBasis");
    bool DV130CSHardshipBasis = xmlGet.getBool();
    xmlGet.find("DV130CSOtherOrdersDetail");
    str381 = xmlGet.getString();
    xmlGet.find("DV130CSCommenceDate");
    csstartdate = xmlGet.getString();
    xmlGet.find("DV130CSHealthCarePetitioner");
    bool DV130CSHealthCarePetitioner = xmlGet.getBool();
    xmlGet.find("DV130CSHealthCareRespondent");
    bool DV130CSHealthCareRespondent = xmlGet.getBool();
    xmlGet.find("DV130CSHealthCareOtherParent");
    bool DV130CSHealthCareOtherParent = xmlGet.getBool();
    xmlGet.find("DV130CSHealthCarePetitionerNone");
    bool DV130CSHealthCarePetitionerNone = xmlGet.getBool();
    xmlGet.find("DV130CSHealthCareRespondentNone");
    bool DV130CSHealthCareRespondentNone = xmlGet.getBool();
    xmlGet.find("DV130CSHealthCareOtherParentNone");
    bool DV130CSHealthCareOtherParentNone = xmlGet.getBool();
    xmlGet.find("DV130CSHealthCareAssignReimbursement");
    bool DV130CSHealthCareAssignReimbursement = xmlGet.getBool();
    xmlGet.find("DV130CSEmploySearchPetitioner");
    bool DV130CSEmploySearchPetitioner = xmlGet.getBool();
    xmlGet.find("DV130CSEmploySearchRespondent");
    bool DV130CSEmploySearchRespondent = xmlGet.getBool();
    xmlGet.find("DV130CSEmploySearchOtherParent");
    bool DV130CSEmploySearchOtherParent = xmlGet.getBool();
    xmlGet.rise();
//stack 6
    xmlGet.findAndDescend("stack6");
    xmlGet.find("DV130TravelRestrictParty");
    str382 = xmlGet.getString();
    xmlGet.find("DV130TravelRestrictROViolation");
    bool DV130TravelRestrictROViolation = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictOutsideCA");
    bool DV130TravelRestrictOutsideCA = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictAction");
    bool DV130TravelRestrictAction = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictQuitJob");
    bool DV130TravelRestrictQuitJob = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictSoldHome");
    bool DV130TravelRestrictSoldHome = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictClosedBank");
    bool DV130TravelRestrictClosedBank = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictEndLease");
    bool DV130TravelRestrictEndLease = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictSoldAssets");
    bool DV130TravelRestrictSoldAssets = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictDestroyDocuments");
    bool DV130TravelRestrictDestroyDocuments = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictApplyPassport");
    bool DV130TravelRestrictApplyPassport = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictPriorHistory");
    bool DV130TravelRestrictPriorHistory = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictDomesticViolence");
    bool DV130TravelRestrictDomesticViolence = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictChildAbuse");
    bool DV130TravelRestrictChildAbuse = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictNoCoopParent");
    bool DV130TravelRestrictNoCoopParent = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictCrimeRecord");
    bool DV130TravelRestrictCrimeRecord = xmlGet.getBool();
    xmlGet.find("DV130TravelRestrictForiegnTies");
    bool DV130TravelRestrictForiegnTies = xmlGet.getBool();
    xmlGet.find("DV130PostBond");
    bool DV130PostBond = xmlGet.getBool();
    xmlGet.find("DV130PostBondAmount");
    str383 = xmlGet.getString();
    xmlGet.find("DV130NoMoveChildren");
    bool DV130NoMoveChildren = xmlGet.getBool();
    xmlGet.find("DV130NoMoveChildrenCounty");
    bool DV130NoMoveChildrenCounty = xmlGet.getBool();
    xmlGet.find("DV130NoMoveChildrenState");
    bool DV130NoMoveChildrenState = xmlGet.getBool();
    xmlGet.find("DV130NoMoveChildrenUSA");
    bool DV130NoMoveChildrenUSA = xmlGet.getBool();
    xmlGet.find("DV130NoMoveChildrenOther");
    bool DV130NoMoveChildrenOther = xmlGet.getBool();
    xmlGet.find("DV130NoMoveChildrenOtherDetail");
    str384 = xmlGet.getString();
    xmlGet.find("DV130NoTravelChildren");
    bool DV130NoTravelChildren = xmlGet.getBool();
    xmlGet.find("DV130NoTravelChildrenCounty");
    bool DV130NoTravelChildrenCounty = xmlGet.getBool();
    xmlGet.find("DV130NoTravelChildrenState");
    bool DV130NoTravelChildrenState = xmlGet.getBool();
    xmlGet.find("DV130NoTravelChildrenUSA");
    bool DV130NoTravelChildrenUSA = xmlGet.getBool();
    xmlGet.find("DV130NoTravelChildrenOther");
    bool DV130NoTravelChildrenOther = xmlGet.getBool();
    xmlGet.find("DV130NoTravelChildrenOtherDetail");
    str385 = xmlGet.getString();
    xmlGet.find("DV130TravelNotifyOtherState");
    bool DV130TravelNotifyOtherState = xmlGet.getBool();
    xmlGet.find("DV130TravelNotifyOtherStateDetail");
    str386 = xmlGet.getString();
    xmlGet.find("DV130TravelPermissionFromParent");
    str387 = xmlGet.getString();
    xmlGet.find("DV130DocumentSurrender");
    bool DV130DocumentSurrender = xmlGet.getBool();
    xmlGet.find("DV130SurrenderTravelDoc");
    str388 = xmlGet.getString();
    xmlGet.find("DV130TravelProvideOrder");
    bool DV130TravelProvideOrder = xmlGet.getBool();
    xmlGet.find("DV130TravelProvideChildItinerary");
    bool DV130TravelProvideChildItinerary = xmlGet.getBool();
    xmlGet.find("DV130TravelProvideAirplaneTickets");
    bool DV130TravelProvideAirplaneTickets = xmlGet.getBool();
    xmlGet.find("DV130TravelProvideAddressPhone");
    bool DV130TravelProvideAddressPhone = xmlGet.getBool();
    xmlGet.find("DV130TravelProvideOtherParentTicket");
    bool DV130TravelProvideOtherParentTicket = xmlGet.getBool();
    xmlGet.find("DV130TravelProvideOther");
    bool DV130TravelProvideOther = xmlGet.getBool();
    xmlGet.find("DV130TravelProvideOtherDetail");
    str389 = xmlGet.getString();
    xmlGet.find("DV130TravelNotifyForiegnEmbassy");
    bool DV130TravelNotifyForiegnEmbassy = xmlGet.getBool();
    xmlGet.find("DV130TravelNotifyForiegnEmbassyDetail");
    str416 = xmlGet.getString();
    xmlGet.find("DV130TravelNotifyForiegnDays");
    str417 = xmlGet.getString();
    xmlGet.find("DV130TravelForiegnCustodyOrder");
    bool DV130TravelForiegnCustodyOrder = xmlGet.getBool();
    xmlGet.find("DV130TravelEnforcingCourtOrder");
    bool DV130TravelEnforcingCourtOrder = xmlGet.getBool();
    xmlGet.find("DV130TravelEnforcingAgencyName");
    str390 = xmlGet.getString();
    xmlGet.find("DV130OtherTravelRestrictionOrder");
    bool DV130OtherTravelRestrictionOrder = xmlGet.getBool();
    xmlGet.find("DV130OtherTravelRestrictionOrdersDetail");
    str391 = xmlGet.getString();
    xmlGet.rise();
//stack 7
    xmlGet.findAndDescend("stack7");
    xmlGet.find("DV130SSAttachmentFOAH");
    bool DV130SSAttachmentFOAH = xmlGet.getBool();
    xmlGet.find("DV130SSAttachmentDVRO");
    bool DV130SSAttachmentDVRO = xmlGet.getBool();
    xmlGet.find("DV130SSAttachmentJudgement");
    bool DV130SSAttachmentJudgement = xmlGet.getBool();
    xmlGet.find("DV130SSAttachmentStipulation");
    bool DV130SSAttachmentStipulation = xmlGet.getBool();
    xmlGet.find("DV130SSAttachmentOther");
    bool DV130SSAttachmentOther = xmlGet.getBool();
    xmlGet.find("DV130SSAttachmentOtherDetail");
    str392 = xmlGet.getString();
    xmlGet.find("DV130SSAttachmentComputerPrintOut");
    bool DV130SSAttachmentComputerPrintOut = xmlGet.getBool();
    xmlGet.find("DV130SSModifiesJudgementOrder");
    bool DV130SSModifiesJudgementOrder = xmlGet.getBool();
    xmlGet.find("DV130SSModifiesJudgementOrderDate");
    judgedate = xmlGet.getString();
    xmlGet.find("DV130SSLengthOfMarriage");
    bool DV130SSLengthOfMarriage = xmlGet.getBool();
    xmlGet.find("DV130SSLengthOfMarriageYears");
    str394 = xmlGet.getString();
    xmlGet.find("DV130SSLengthOfMarriageMonths");
    str395 = xmlGet.getString();
    xmlGet.find("DV130SSLengthOfDomesticPartnership");
    bool DV130SSLengthOfDomesticPartnership = xmlGet.getBool();
    xmlGet.find("DV130SSLengthOfDomesticPartnershipYears");
    str396 = xmlGet.getString();
    xmlGet.find("DV130SSLengthOfDomesticPartnershipMonths");
    str397 = xmlGet.getString();
    xmlGet.find("DV130SSPartiesSelfSupporting");
    bool DV130SSPartiesSelfSupporting = xmlGet.getBool();
    xmlGet.find("DV130SSMaritalSOL");
    bool DV130SSMaritalSOL = xmlGet.getBool();
    xmlGet.find("DV130SSMaritalSOLAttach");
    bool DV130SSMaritalSOLAttach = xmlGet.getBool();
    xmlGet.find("DV130SSMaritalSOLDetail");
    str398 = xmlGet.getString();
    xmlGet.find("DV130SSReservationOfSupport");
    bool DV130SSReservationOfSupport = xmlGet.getBool();
    xmlGet.find("DV130SSReservationOfSupportPlaintiff");
    bool DV130SSReservationOfSupportPlaintiff = xmlGet.getBool();
    xmlGet.find("DV130SSReservationOfSupportRespondent");
    bool DV130SSReservationOfSupportRespondent = xmlGet.getBool();
    xmlGet.find("DV130SSTerminationOfSupport");
    bool DV130SSTerminationOfSupport = xmlGet.getBool();
    xmlGet.find("DV130SSTerminationOfSupportPlaintiff");
    bool DV130SSTerminationOfSupportPlaintiff = xmlGet.getBool();
    xmlGet.find("DV130SSTerminationOfSupportRespondent");
    bool DV130SSTerminationOfSupportRespondent = xmlGet.getBool();
    xmlGet.find("DV130SSReservationOfSupportPaidBy");
    bh = xmlGet.getInt();
    xmlGet.find("DV130SSReservationOfSupportPaidTo");
    bi = xmlGet.getInt();
    xmlGet.find("DV130SSReservationOfSupportTemporary");
    bool DV130SSReservationOfSupportTemporary = xmlGet.getBool();
    xmlGet.find("DV130SSReservationOfSupportSpousal");
    bool DV130SSReservationOfSupportSpousal = xmlGet.getBool();
    xmlGet.find("DV130SSReservationOfSupportFamily");
    bool DV130SSReservationOfSupportFamily = xmlGet.getBool();
    xmlGet.find("DV130SSReservationOfSupportPartner");
    bool DV130SSReservationOfSupportPartner = xmlGet.getBool();
    xmlGet.find("DV130SSReservationOfSupportAmount");
    str399 = xmlGet.getString();
    xmlGet.find("DV130SSReservationOfSupportStartDate");
    supportstart = xmlGet.getString();
    xmlGet.find("DV130SSReservationOfSupportPayable");
    str1 = xmlGet.getString();
    xmlGet.find("DV130SSReservationOfSupportPayableOther");
    bool DV130SSReservationOfSupportPayableOther = xmlGet.getBool();
    xmlGet.find("DV130SSReservationOfSupportPayableSchedule");
    str2 = xmlGet.getString();
    xmlGet.find("DV130SSReservationOfSupportEndDate");
    supportend = xmlGet.getString();
    xmlGet.find("DV130SSSupportPayableCash");
    bool DV130SSSupportPayableCash = xmlGet.getBool();
    xmlGet.find("DV130SSSupportNotifyEmployChange");
    bool DV130SSSupportNotifyEmployChange = xmlGet.getBool();
    xmlGet.find("DV130SSSupportCSRegistry");
    bool DV130SSSupportCSRegistry = xmlGet.getBool();
    xmlGet.find("DV130SSSupportSelfSupport");
    bool DV130SSSupportSelfSupport = xmlGet.getBool();
    xmlGet.find("DV130SSSupportSelfSupportPlaintiff");
    bool DV130SSSupportSelfSupportPlaintiff = xmlGet.getBool();
    xmlGet.find("DV130SSSupportSelfSupportRespondent");
    bool DV130SSSupportSelfSupportRespondent = xmlGet.getBool();
    xmlGet.find("DV130SSSupportEarningAssesment");
    bool DV130SSSupportEarningAssesment = xmlGet.getBool();
    xmlGet.find("DV130SSSupportServicedStayedLate");
    bool DV130SSSupportServicedStayedLate = xmlGet.getBool();
    xmlGet.find("DV130SSSupportServicedStayedLateDays");
    str3 = xmlGet.getString();
    xmlGet.find("DV130SSSupportDurationOfDVOrder");
    bool DV130SSSupportDurationOfDVOrder = xmlGet.getBool();
    xmlGet.find("DV130SSSupportOtherOrders");
    bool DV130SSSupportOtherOrders = xmlGet.getBool();
    xmlGet.find("DV130SSSupportOtherOrdersDetail");
    str4 = xmlGet.getString();
    xmlGet.findAndDescend("DV130FamilySupport");
    xmlGet.findAndDescend("DV130IncomePlaintiff");
    xmlGet.find("SSDesignation");
    str10 = xmlGet.getString();
    xmlGet.find("SSFullName");
    str11 = xmlGet.getString();
    xmlGet.find("SSGrossMo");
    str12 = xmlGet.getString();
    xmlGet.find("SSDeductMo");
    str13 = xmlGet.getString();
    xmlGet.find("SSHardshipMo");
    str14 = xmlGet.getString();
    xmlGet.find("SSCalWorks");
    str15 = xmlGet.getString();
    xmlGet.find("SSNetMo");
    str16 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.find("DV130IncomeRespondent");
    xmlGet.descend();
    xmlGet.find("SSDesignation");
    str17 = xmlGet.getString();
    xmlGet.find("SSFullName");
    str18 = xmlGet.getString();
    xmlGet.find("SSGrossMo");
    str19 = xmlGet.getString();
    xmlGet.find("SSDeductMo");
    str20 = xmlGet.getString();
    xmlGet.find("SSHardshipMo");
    str21 = xmlGet.getString();
    xmlGet.find("SSCalWorks");
    str22 = xmlGet.getString();
    xmlGet.find("SSNetMo");
    str23 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();

//Load Stack 1
    ui->radioButton_DV130POSDelivered->setChecked(DV130POSDelivered);
    ui->radioButton_DV130POSNotDeliveredP1->setChecked(DV130POSNotDeliveredP1);
    ui->checkBox_DV130Conduct->setChecked(DV130Conduct);
    ui->checkBox_DV130NoContact->setChecked(DV130Contact);
    ui->checkBox_DV130NoHarass->setChecked(DV130Harass);
    ui->checkBox_DV130NoLocate->setChecked(DV130Locate);
    ui->checkBox_DV130ConductException->setChecked(DV130ConductException);
    ui->checkBox_DV130StayAway->setChecked(DV130StayAway);
    ui->lineEdit_DV130StayAwayDistance->setText(str300);
    ui->checkBox_DV130NoPerson->setChecked(DV130NoPerson);
    ui->checkBox_DV130NoWork->setChecked(DV130NoWork);
    ui->checkBox_DV130NoSchool->setChecked(DV130NoSchool);
    ui->checkBox_DV130NoHome->setChecked(DV130NoHome);
    ui->checkBox_DV130NoChildCare->setChecked(DV130NoChildCare);
    ui->checkBox_DV130NoVehicle->setChecked(DV130NoVehicle);
    ui->checkBox_DV130StayAwayOther->setChecked(DV130StayAwayOther);
    ui->checkBox_DV130StayAwayAttach->setChecked(DV130StayAwayAttach);
    ui->textEdit_DV130StayAwayOtherDetail->setText(str301);
    ui->checkBox_DV130MoveOut->setChecked(DV130MoveOut);
    ui->lineEdit_DV130MoveOutAddress->setText(str302);
    ui->checkBox_DV130CommunicationsRecording->setChecked(DV130CommunicationsRecording);
    ui->checkBox_DV130Animals->setChecked(DV130Animals);
    ui->lineEdit_DV130AnimalsDistance->setText(str303);
    ui->lineEdit_DV130AnimalsDetail->setText(str304);
    ui->checkBox_DV130OtherOrders->setChecked(DV130OtherOrders);
    ui->textEdit_DV130OtherOrdersDetail->setText(str305);
    ui->checkBox_DV130BatterIntervention->setChecked(DV130BatterIntervention);
    ui->checkBox_DV130FireArms->setChecked(DV130FireArms);
    ui->checkBox_DV130NoExpire->setChecked(DV130NoExpire);
    ui->checkBox_DV130Expire->setChecked(DV130Expire);
    QTime xtime = QTime::fromString(expiretime,"hh:mm:ss");
    ui->timeEdit_DV130ExpireTime->setTime(xtime);   
    QDate xdate = QDate::fromString(expiredate,"MM-dd-yyyy");
    ui->dateEdit_DV130ExpireDate->setDisplayFormat("MMM-dd-yyyy");
    ui->dateEdit_DV130ExpireDate->setDate(xdate);  


//Setup DV130 Other Protected Table
    ui->treeWidget_DV130OthersProtected->setColumnCount(2);
    ui->treeWidget_DV130OthersProtected->setColumnWidth(0,90);
    ui->treeWidget_DV130OthersProtected->setColumnWidth(1,120);
    ui->treeWidget_DV130OthersProtected->setHeaderLabels(QStringList() << "ENTITY" << "FULL NAME");
    AddRootDV130OtherProtect(str306, str307);
    AddRootDV130OtherProtect(str308, str309);

//Load Stack2
    ui->checkBox_DV130PropertyControl->setChecked(DV130PropertyControl);
    ui->checkBox_DV130DebtPayment->setChecked(DV130DebtPayment);
    ui->checkBox_DV130PropertyRestraint->setChecked(DV130PropertyRestraint);
    ui->checkBox_DV130PropertyRestraintProtected->setChecked(DV130PropertyRestraintProtected);
    ui->checkBox_DV130PropertyRestraintRestrained->setChecked(DV130PropertyRestraintRestrained);


//Load Stack3

//Child Custody Table
    ui->treeWidget_DV130Children->setColumnCount(6);
    ui->treeWidget_DV130Children->setColumnWidth(0,90);
    ui->treeWidget_DV130Children->setColumnWidth(1,150);
    ui->treeWidget_DV130Children->setColumnWidth(2,150);
    ui->treeWidget_DV130Children->setColumnWidth(3,120);
    ui->treeWidget_DV130Children->setColumnWidth(4,120);
    ui->treeWidget_DV130Children->setColumnWidth(4,120);
    ui->treeWidget_DV130Children->setHeaderLabels(QStringList() << "ENTITY" << "FIRST NAME" << "LAST NAME" << "DATE OF BIRTH" << "LEGAL CUSTODY" << "PHYSICAL CUSTODY");
    AddRootDV130Children(str311, childfname1, childlname1, str314, str315, str316);
    AddRootDV130Children(str317, childfname2, childlname2, str320, str321, str322);

    ui->checkBox_DV130VisitationOrders->setChecked(DV130VisitationOrders);
    ui->checkBox_DV130VisitationOtherParent->setChecked(DV130VisitationOtherParent);
    ui->lineEdit_DV130OtherParentName->setText(str323);
    ui->checkBox_DV130NoVisitation->setChecked(DV130NoVisitation);
    ui->comboBox_DV130NoVisitationParent->setCurrentIndex(ba);
    ui->lineEdit_DV130OtherParentNoVisit->setText(str418);
    ui->checkBox_DV130VisitationMediation->setChecked(DV130VisitationMediation);
    ui->lineEdit_DV130VisitationMediationProvider->setText(str324);
    ui->checkBox_DV130VisitationAttachment->setChecked(DV130VisitationAttachment);
    ui->lineEdit_DV130VisitationAttachmentPages->setText(str325);
    ui->lineEdit_DV130VisitationAttachmentDate->setText(str326);
    ui->checkBox_DV130VisitationGrantedTo->setChecked(DV130VisitationGrantedTo);
    ui->comboBox_DV130VisitationParent->setCurrentIndex(bb);
    ui->lineEdit_DV130VisitationOtherParentName->setText(str327);

    ui->checkBox_DV130ScheduleWeekends->setChecked(DV130ScheduleWeekends);

    QDate vdate = QDate::fromString(weekenddate,"MM-dd-yyyy");
    ui->dateEdit_DV130CommenceDate->setDate(vdate);

    ui->checkBox_DV130ScheduleWeekendMonth1->setChecked(DV130ScheduleWeekendMonth1);
    ui->checkBox_DV130ScheduleWeekendMonth2->setChecked(DV130ScheduleWeekendMonth2);
    ui->checkBox_DV130ScheduleWeekendMonth3->setChecked(DV130ScheduleWeekendMonth3);
    ui->checkBox_DV130ScheduleWeekendMonth4->setChecked(DV130ScheduleWeekendMonth4);
    ui->checkBox_DV130ScheduleWeekendMonth5->setChecked(DV130ScheduleWeekendMonth5);
    ui->lineEdit_DV130ScheduleWeekendStartDay->setText(str328);
    ui->lineEdit_DV130ScheduleWeekendEndDay->setText(str329);

    QTime starttime1 = QTime::fromString(stime1,"hh:mm:ss");
    ui->timeEdit_DV130ScheduleWeekendsStartTime->setTime(starttime1);
    QTime endtime1 = QTime::fromString(etime1,"hh:mm:ss");

    ui->timeEdit_DV130ScheduleWeekendsEndTime->setTime(endtime1);

    ui->checkBox_DV130ScheduleWeekdays->setChecked(DV130ScheduleWeekdays);
    ui->lineEdit_DV130ScheduleWeekdayStartDay->setText(str330);
    ui->lineEdit_DV130ScheduleWeekdayEndDay->setText(str331);

    QTime starttime2 = QTime::fromString(stime2,"hh:mm:ss");
    ui->timeEdit_DV130ScheduleWeekdaysStartTime->setTime(starttime2);
    QTime endtime2 = QTime::fromString(etime2,"hh:mm:ss");
    ui->timeEdit_DV130ScheduleWeekdaysEndTime->setTime(endtime2);

    ui->checkBox_DV130ScheduleVisitationOther->setChecked(DV130ScheduleVisitationOther);
    ui->checkBox_DV130ExchangeRemove->setChecked(DV130ExchangeRemove);

    ui->checkBox_DV130TransportOrders->setChecked(DV130TransportOrders);
    ui->comboBox_DV130TransportFromParty->setCurrentIndex(bc);
    ui->lineEdit_DV130TransportFromPartyOther->setText(str332);
    ui->lineEdit_DV130TransportFromLocation->setText(str333);
    ui->comboBox_DV130TransportToParty->setCurrentIndex(bd);
    ui->lineEdit_DV130TransportToPartyOther->setText(str334);
    ui->lineEdit_DV130TransportToLocation->setText(str335);

    ui->checkBox_DV130TravelRestrictOrders->setChecked(DV130TravelRestrictOrders);
    ui->checkBox_DV130TravelRestrictMom->setChecked(DV130TravelRestrictMom);
    ui->checkBox_DV130TravelRestrictDad->setChecked(DV130TravelRestrictDad);
    ui->checkBox_DV130TravelRestrictOtherParent->setChecked(DV130TravelRestrictOtherParent);
    ui->lineEdit_DV130TravelRestrictOtherParentDetail->setText(str336);
    ui->checkBox_DV130TravelRestrictUSA->setChecked(DV130TravelRestrictUSA);
    ui->checkBox_DV130TravelRestrictCA->setChecked(DV130TravelRestrictCA);
    ui->checkBox_DV130TravelRestrictOtherLocation->setChecked(DV130TravelRestrictOtherLocation);
    ui->lineEdit_DV130TravelRestrictOtherLocationDetail->setText(str337);

    ui->checkBox_DV130HabitualResidencyUS->setChecked(DV130HabitualResidencyUS);
    ui->checkBox_DV130HabitualResidencyOther->setChecked(DV130HabitualResidencyOther);
    ui->lineEdit_DV130HabitualResidencyotherDetail->setText(str338);
    ui->checkBox_DV130ChildAbductionRisk->setChecked(DV130ChildAbductionRisk);
    ui->checkBox_DV130AttachDV145->setChecked(DV130AttachDV145);
    ui->checkBox_DV130ChildCustodyOtherOrders->setChecked(DV130ChildCustodyOtherOrders);
    ui->textEdit_DV130ChildCustodyOtherOrdersDetail->setText(str339);

    ui->checkBox_DV130SupervisionMediation->setChecked(DV130SupervisionMediation);
    ui->checkBox_DV130VisitationSupervised->setChecked(DV130VisitationSupervised);
    ui->checkBox_DV130ExchangesSupervised->setChecked(DV130ExchangesSupervised);
    ui->lineEdit_DV130SupervisionMediationLocation->setText(str340);
    ui->comboBox_DV130SupervisionParent->setCurrentIndex(be);
    ui->lineEdit_DV130SupervisionOtherParentName->setText(str341);

    ui->checkBox_DV130SupervisionAllVisits->setChecked(DV130SupervisionAllVisits);
    ui->lineEdit_DV130SupervisionVisitsWeek->setText(str342);
    ui->lineEdit_DV130SupervisionHoursVisit->setText(str343);
    ui->checkBox_DV130SupervisionOtherSchedule->setChecked(DV130SupervisionOtherSchedule);
    ui->textEdit_DV130SupervisionOtherSchedule->setText(str344);
    ui->radioButton_DV130SupervisionProfessional->setChecked(DV130SupervisionProfessional);
    ui->radioButton_DV130SupervisionNonProfessional->setChecked(DV130SupervisionNonProfessional);
    ui->radioButton_DV130SupervisionTherapeutic->setChecked(DV130SupervisionTherapeutic);
    ui->checkBox_DV130SupervisionMomPays->setChecked(DV130SupervisionMomPays);
    ui->checkBox_DV130SupervisionDadPays->setChecked(DV130SupervisionDadPays);
    ui->checkBox_DV130SupervisionOtherPays->setChecked(DV130SupervisionOtherPays);
    ui->lineEdit_DV130SupervisionOtherPaysName->setText(str345);

    ui->checkBox_DV130SupervisionMomContactBefore->setChecked(DV130SupervisionMomContactBefore);
    ui->checkBox_DV130SupervisionDadContactBefore->setChecked(DV130SupervisionDadContactBefore);
    ui->checkBox_DV130SupervisionOtherContactBefore->setChecked(DV130SupervisionOtherContactBefore);

    ui->lineEdit_DV130SupervisionMomPaysAmount->setText(str346);
    ui->lineEdit_DV130SupervisionDadPaysAmount->setText(str347);
    ui->lineEdit_DV130SupervisionOtherPaysAmount->setText(str348);
    QDate contactDateMom = QDate::fromString(contactdate1, "MM-dd-yyyy");
    ui->dateEdit_DV130SupervisionMomContactDate->setDate(contactDateMom);
    QDate contactDateDad = QDate::fromString(contactdate2, "MM-dd-yyyy");
    ui->dateEdit_DV130SupervisionDadContactDate->setDate(contactDateDad);
    ui->lineEdit_DV130SupervisionProviderName->setText(str349);
    ui->lineEdit_DV130SupervisionProviderAddress->setText(str350);
    ui->lineEdit_DV130SupervisionProviderPhone->setText(str351);
    ui->textEdit_DV130SupervisionOtherOrders->setText(str352);

    ui->checkBox_DV130CSAttachmentFOAH->setChecked(DV130CSAttachmentFOAH);
    ui->checkBox_DV130CSAttachmentDVRO->setChecked(DV130CSAttachmentDVRO);
    ui->checkBox_DV130CSAttachmentJudgement->setChecked(DV130CSAttachmentJudgement);
    ui->checkBox_DV130CSAttachmentOther->setChecked(DV130CSAttachmentOther);
    ui->lineEdit_DV130CSAttachmentOtherDetail->setText(str353);
    ui->checkBox_DV130CSComputerPrintOut->setChecked(DV130CSAttachmentComputerPrintOut);
    ui->checkBox_DV130CSNonGuidelineOrder->setChecked(DV130CSNonGuidelineOrder);

    ui->radioButton_DV130CSPaymentFirstMonth->setChecked(DV130CSPaymentFirstMonth);
    ui->radioButton_DV130CSPaymentTwiceMonth->setChecked(DV130CSPaymentTwiceMonth);
    ui->radioButton_DV130CSPaymentOther->setChecked(DV130CSPaymentOther);
    ui->lineEdit_DV130CSPaymentOtherDetail->setText(str358);
    ui->comboBox_DV130CSPaymentPaidByParty->setCurrentIndex(bf);
    ui->comboBox_DV130CSPaymentPayToParty->setCurrentIndex(bg);
    ui->checkBox_DV130CSLowIncomeBasis->setChecked(DV130CSLowIncomeBasis);
    ui->checkBox_DV130CSLowIncomeNotApply->setChecked(DV130CSLowIncomeNotApply);
    ui->lineEdit_DV130CSLowIncomeNotApplyDetail->setText(str359);
    ui->checkBox_DV130CSIncomeBasis->setChecked(DV130CSIncomeBasis);

    ui->checkBox_DV130CSTimeShareBasis->setChecked(DV130CSTimeShareBasis);
    ui->lineEdit_DV130CSTimeSharePlaintiff->setText(str378);
    ui->lineEdit_DV130CSTimeShareRespondent->setText(str379);
    ui->lineEdit_DV130CSTimeShareOtherParent->setText(str380);
    ui->checkBox_DV130CSHardshipBasis->setChecked(DV130CSHardshipBasis);
    ui->lineEdit_DV130CSOtherOrdersDetail->setText(str381);
    QDate cscommencedate = QDate::fromString(csstartdate, "MM-dd-yyyy");
    ui->dateEdit_DV130CSCommenceDate->setDate(cscommencedate);
    ui->checkBox_DV130CSHealthCarePlaintiff->setChecked(DV130CSHealthCarePetitioner);
    ui->checkBox_DV130CSHealthCareRespondent->setChecked(DV130CSHealthCareRespondent);
    ui->checkBox_DV130CSHealthCareOtherParent->setChecked(DV130CSHealthCareOtherParent);
    ui->checkBox_DV130CSHealthCarePlaintiffNone->setChecked(DV130CSHealthCarePetitionerNone);
    ui->checkBox_DV130CSHealthCareRespondentNone->setChecked(DV130CSHealthCareRespondentNone);
    ui->checkBox_DV130CSHealthCareOtherParentNone->setChecked(DV130CSHealthCareOtherParentNone);
    ui->checkBox_DV130CSHealthCareAssignReimbursement->setChecked(DV130CSHealthCareAssignReimbursement);
    ui->checkBox_DV130CSEmploySearchPlaintiff->setChecked(DV130CSEmploySearchPetitioner);
    ui->checkBox_DV130CSEmploySearchRespondent->setChecked(DV130CSEmploySearchRespondent);
    ui->checkBox_DV130CSEmploySearchOtherParent->setChecked(DV130CSEmploySearchOtherParent);
// Load Stack 6
    ui->lineEdit_DV130TravelRestrictParty->setText(str382);
    ui->checkBox_DV130TravelRestrictROViolation->setChecked(DV130TravelRestrictROViolation);
    ui->checkBox_DV130TravelRestrictOutsideCA->setChecked(DV130TravelRestrictOutsideCA);
    ui->checkBox_DV130TravelRestrictAction->setChecked(DV130TravelRestrictAction);
    ui->checkBox_DV130TravelRestrictQuitJob->setChecked(DV130TravelRestrictQuitJob);
    ui->checkBox_DV130TravelRestrictSoldHome->setChecked(DV130TravelRestrictSoldHome);
    ui->checkBox_DV130TravelRestrictClosedBank->setChecked(DV130TravelRestrictClosedBank);
    ui->checkBox_DV130TravelRestrictEndLease->setChecked(DV130TravelRestrictEndLease);
    ui->checkBox_DV130TravelRestrictSoldAssets->setChecked(DV130TravelRestrictSoldAssets);
    ui->checkBox_DV130TravelRestrictDestroyDocuments->setChecked(DV130TravelRestrictDestroyDocuments);
    ui->checkBox_DV130TravelRestrictApplyPassport->setChecked(DV130TravelRestrictApplyPassport);
    ui->checkBox_DV130TravelRestrictPriorHistory->setChecked(DV130TravelRestrictPriorHistory);
    ui->checkBox_DV130TravelRestrictDomesticViolence->setChecked(DV130TravelRestrictDomesticViolence);
    ui->checkBox_DV130TravelRestrictChildAbuse->setChecked(DV130TravelRestrictChildAbuse);
    ui->checkBox_DV130TravelRestrictNoCoopParent->setChecked(DV130TravelRestrictNoCoopParent);
    ui->checkBox_DV130TravelRestrictCrimeRecord->setChecked(DV130TravelRestrictCrimeRecord);
    ui->checkBox_DV130TravelRestrictForiegnTies->setChecked(DV130TravelRestrictForiegnTies);
    ui->checkBox_DV130PostBond->setChecked(DV130PostBond);
    ui->lineEdit_DV130PostBondAmount->setText(str383);
    ui->checkBox_DV130NoMoveChildren->setChecked(DV130NoMoveChildren);
    ui->checkBox_DV130NoMoveChildrenCounty->setChecked(DV130NoMoveChildrenCounty);
    ui->checkBox_DV130NoMoveChildrenState->setChecked(DV130NoMoveChildrenState);
    ui->checkBox_DV130NoMoveChildrenUSA->setChecked(DV130NoMoveChildrenUSA);
    ui->checkBox_DV130NoMoveChildrenOther->setChecked(DV130NoMoveChildrenOther);
    ui->lineEdit_DV130NoMoveChildrenOtherDetail->setText(str384);
    ui->checkBox_DV130NoTravelChildren->setChecked(DV130NoTravelChildren);
    ui->checkBox_DV130NoTravelChildrenCounty->setChecked(DV130NoTravelChildrenCounty);
    ui->checkBox_DV130NoTravelChildrenState->setChecked(DV130NoTravelChildrenState);
    ui->checkBox_DV130NoTravelChildrenUSA->setChecked(DV130NoTravelChildrenUSA);
    ui->checkBox_DV130NoTravelChildrenOther->setChecked(DV130NoTravelChildrenOther);
    ui->lineEdit_DV130NoTravelChildrenOtherDetail->setText(str385);
    ui->checkBox_DV130TravelNotifyOtherState->setChecked(DV130TravelNotifyOtherState);
    ui->lineEdit_DV130TravelNotifyOtherStateDetail->setText(str386);
    ui->lineEdit_DV130TravelPermissionFromParent->setText(str387);
    ui->checkBox_DV130DocumentSurrender->setChecked(DV130DocumentSurrender);
    ui->lineEdit_DV130SurrenderTravelDocs->setText(str388);
    ui->checkBox_DV130TravelProvideOrder->setChecked(DV130TravelProvideOrder);
    ui->checkBox_DV130TravelProvideChildItinerary->setChecked(DV130TravelProvideChildItinerary);
    ui->checkBox_DV130TravelProvideAirplaneTickets->setChecked(DV130TravelProvideAirplaneTickets);
    ui->checkBox_DV130TravelProvideAddressPhone->setChecked(DV130TravelProvideAddressPhone);
    ui->checkBox_DV130TravelProvideOtherParentTicket->setChecked(DV130TravelProvideOtherParentTicket);
    ui->checkBox_DV130TravelProvideOther->setChecked(DV130TravelProvideOther);
    ui->lineEdit_DV130TravelProvideOtherDetail->setText(str389);

    ui->checkBox_DV130TravelNotifyForiegnEmbassy->setChecked(DV130TravelNotifyForiegnEmbassy);
    ui->lineEdit_DV130TravelNotifyForiegnEmbassyDetail->setText(str416);
    ui->lineEdit_DV130TravelNotifyForiegnEmbassyDays->setText(str417);

    ui->checkBox_DV130TravelForiegnCustodyOrder->setChecked(DV130TravelForiegnCustodyOrder);
    ui->checkBox_DV130TravelEnforcingCourtOrder->setChecked(DV130TravelEnforcingCourtOrder);
    ui->lineEdit_DV130TravelEnforcingAgencyName->setText(str390);
    ui->checkBox_DV130OtherTravelRestrictionOrder->setChecked(DV130OtherTravelRestrictionOrder);
    ui->textEdit_DV130OtherTravelRestrictionOrdersDetail->setText(str391);

//stack 7
    ui->checkBox_DV130SSAttachmentFOAH->setChecked(DV130SSAttachmentFOAH);
    ui->checkBox_DV130SSAttachmentDVRO->setChecked(DV130SSAttachmentDVRO);
    ui->checkBox_DV130SSAttachmentJudgement->setChecked(DV130SSAttachmentJudgement);
    ui->checkBox_DV130SSAttachmentStipulation->setChecked(DV130SSAttachmentStipulation);
    ui->checkBox_DV130SSAttachmentOther->setChecked(DV130SSAttachmentOther);
    ui->lineEdit_DV130SSAttachmentOtherDetail->setText(str392);
    ui->checkBox_DV130SSAttachmentComputerPrintOut->setChecked(DV130SSAttachmentComputerPrintOut);
    ui->checkBox_DV130SSModifiesJudgementOrder->setChecked(DV130SSModifiesJudgementOrder);

    QDate judgementdate = QDate::fromString(judgedate, "MM-dd-yyyy");
    ui->dateEdit_DV130SSModifiesJudgementOrderDate->setDate(judgementdate);
    ui->checkBox_DV130SSLengthOfMarriage->setChecked(DV130SSLengthOfMarriage);
    ui->lineEdit_DV130SSLengthOfMarriageYears->setText(str394);
    ui->lineEdit_DV130SSLengthOfMarriageMonths->setText(str395);
    ui->checkBox_DV130SSLengthOfDomesticPartnership->setChecked(DV130SSLengthOfDomesticPartnership);
    ui->lineEdit_DV130SSLengthOfDomesticPartnershipYears->setText(str396);
    ui->lineEdit_DV130SSLengthOfDomesticPartnershipMonths->setText(str397);
    ui->checkBox_DV130SSPartiesSelfSupporting->setChecked(DV130SSPartiesSelfSupporting);
    ui->checkBox_DV130SSMaritalSOL->setChecked(DV130SSMaritalSOL);
    ui->checkBox_DV130SSMaritalSOLAttached->setChecked(DV130SSMaritalSOLAttach);
    ui->textEdit_DV130SSMaritalSOLDetail->setText(str398);
    ui->checkBox_DV130SSReservationOfSupport->setChecked(DV130SSReservationOfSupport);
    ui->checkBox_DV130SSReservationOfSupportPlaintiff->setChecked(DV130SSReservationOfSupportPlaintiff);
    ui->checkBox_DV130SSReservationOfSupportRespondent->setChecked(DV130SSReservationOfSupportRespondent);
    ui->checkBox_DV130SSTerminationOfSupport->setChecked(DV130SSTerminationOfSupport);
    ui->checkBox_DV130SSTerminationOfSupportPlaintiff->setChecked(DV130SSTerminationOfSupportPlaintiff);
    ui->checkBox_DV130SSTerminationOfSupportRespondent->setChecked(DV130SSTerminationOfSupportRespondent);
    ui->comboBox_DV130SSReservationOfSupportPaidBy->setCurrentIndex(bh);
    ui->comboBox_DV130SSReservationOfSupportPaidTo->setCurrentIndex(bi);
    ui->checkBox_DV130SSReservationOfSupportTemporary->setChecked(DV130SSReservationOfSupportTemporary);
    ui->checkBox_DV130SSReservationOfSupportSpousal->setChecked(DV130SSReservationOfSupportSpousal);
    ui->checkBox_DV130SSReservationOfSupportFamily->setChecked(DV130SSReservationOfSupportFamily);
    ui->checkBox_DV130SSReservationOfSupportPartner->setChecked(DV130SSReservationOfSupportPartner);
    ui->lineEdit_DV130SSReservationOfSupportAmount->setText(str399);

    QDate supportstartdate = QDate::fromString(supportstart, "MM-dd-yyyy");
    ui->dateEdit_DV130SSReservationOfSupportStartDate->setDate(supportstartdate);
    ui->lineEdit_DV130SSReservationOfSupportPayable->setText(str1);
    ui->lineEdit_DV130SSReservationOfSupportPayableSchedule->setText(str2);
    ui->checkBox_DV130SSReservationOfSupportPayableOther->setChecked(DV130SSReservationOfSupportPayableOther);

    QDate supportenddate = QDate::fromString(supportend, "MM-dd-yyyy");
    ui->dateEdit_DV130SSReservationOfSupportEndDate->setDate(supportenddate);

    ui->checkBox_DV130SSSupportPayableCash->setChecked(DV130SSSupportPayableCash);
    ui->checkBox_DV130SSSupportNotifyEmployChange->setChecked(DV130SSSupportNotifyEmployChange);
    ui->checkBox_DV130SSSupportCSRegistry->setChecked(DV130SSSupportCSRegistry);
    ui->checkBox_DV130SSSupportSelfSupport->setChecked(DV130SSSupportSelfSupport);
    ui->radioButton_DV130SSSupportSelfSupportPlaintiff->setChecked(DV130SSSupportSelfSupportPlaintiff);
    ui->radioButton_DV130SSSupportSelfSupportRespondent->setChecked(DV130SSSupportSelfSupportRespondent);
    ui->checkBox_DV130SSSupportEarningAssesment->setChecked(DV130SSSupportEarningAssesment);
    ui->checkBox_DV130SSSupportServicedStayedLate->setChecked(DV130SSSupportServicedStayedLate);
    ui->lineEdit_DV130SSSupportServicedStayedLateDays->setText(str3);
    ui->checkBox_DV130SSSupportDurationOfDVOrder->setChecked(DV130SSSupportDurationOfDVOrder);
    ui->checkBox_DV130SSSupportOtherOrders->setChecked(DV130SSSupportOtherOrders);
    ui->lineEdit_DV130SSSupportOtherOrdersDetail->setText(str4);

//ChildSupport Child Base Table
    ui->treeWidget_DV130ChildSupport->setColumnCount(4);
    ui->treeWidget_DV130ChildSupport->setColumnWidth(0,120);
    ui->treeWidget_DV130ChildSupport->setColumnWidth(1,120);
    ui->treeWidget_DV130ChildSupport->setColumnWidth(2,200);
    ui->treeWidget_DV130ChildSupport->setColumnWidth(3,90);
    ui->treeWidget_DV130ChildSupport->setHeaderLabels(QStringList() << "FIRST NAME" << "LAST NAME" << "PAID TO" << "MO. AMOUNT");
    AddRootDV130ChildSupport(childfname1, childlname1, str354, str355);
    AddRootDV130ChildSupport(childfname2, childlname2, str356, str357);

//Property Control Table
    ui->treeWidget_DV130PropertyControl->setColumnCount(2);
    ui->treeWidget_DV130PropertyControl->setColumnWidth(0,150);
    ui->treeWidget_DV130PropertyControl->setColumnWidth(1,400);
    ui->treeWidget_DV130PropertyControl->setHeaderLabels(QStringList() << "PROPERTY ITEM" << "PROPERTY GIVEN TO");
    AddRootDV130PropertyControl(str400, str401);
    AddRootDV130PropertyControl(str402, str403);
    AddRootDV130PropertyControl(str404, str405);

//Payments Table
    ui->treeWidget_DV130Payments->setColumnCount(5);
    ui->treeWidget_DV130Payments->setColumnWidth(0,150);
    ui->treeWidget_DV130Payments->setColumnWidth(1,150);
    ui->treeWidget_DV130Payments->setColumnWidth(2,150);
    ui->treeWidget_DV130Payments->setColumnWidth(3,150);
    ui->treeWidget_DV130Payments->setColumnWidth(4,150);
    ui->treeWidget_DV130Payments->setHeaderLabels(QStringList() << "DEBT ITEM" << "PAYMENT TO" << "PAYMENT FOR" << "PAYMENT FROM" << "DATE");
    AddRootDV130DebtPayment(str406, str407, str408, str409, str410);
    AddRootDV130DebtPayment(str411, str412, str413, str414, str415);

//Income Table
    ui->treeWidget_DV130Income->setColumnCount(6);
    ui->treeWidget_DV130Income->setColumnWidth(0,80);
    ui->treeWidget_DV130Income->setColumnWidth(1,80);
    ui->treeWidget_DV130Income->setColumnWidth(2,80);
    ui->treeWidget_DV130Income->setColumnWidth(3,100);
    ui->treeWidget_DV130Income->setColumnWidth(4,120);
    ui->treeWidget_DV130Income->setColumnWidth(5,90);
    ui->treeWidget_DV130Income->setHeaderLabels(QStringList() << "ROLE" << "GROSS MO." << "NET MONTH" << "TANF CALWORKS" << "YR. IMPUTED INC." << "MO. IMPUTED INC.");
    AddRootDV130Income(str360, str361, str362, str363, str364, str365);
    AddRootDV130Income(str366, str367, str368, str369, str370, str371);
    AddRootDV130Income(str372, str373, str374, str375, str376, str377);

//Hardship Table
    ui->treeWidget_DV130Hardship->setColumnCount(5);
    ui->treeWidget_DV130Hardship->setColumnWidth(0,120);
    ui->treeWidget_DV130Hardship->setColumnWidth(1,100);
    ui->treeWidget_DV130Hardship->setColumnWidth(2,100);
    ui->treeWidget_DV130Hardship->setColumnWidth(3,100);
    ui->treeWidget_DV130Hardship->setColumnWidth(4,90);
    ui->treeWidget_DV130Hardship->setHeaderLabels(QStringList() << "HARDSHIP" << "PLAINTIFF" << "RESPONDENT" << "OTHER PARENT" << "END DATE");
    AddRootDV130Hardship("Other Children", "3000", "", "", "12/20/2016");
    AddRootDV130Hardship("Catastrophic Loss", "", "6000", "", "3/12/2016");
    AddRootDV130Hardship("Medical Issue", "1200", "", "", "3/12/2016");

//Family Support Table
    ui->treeWidget_DV130FamilySupport->setColumnCount(7);
    ui->treeWidget_DV130FamilySupport->setColumnWidth(0,100);
    ui->treeWidget_DV130FamilySupport->setColumnWidth(1,140);
    ui->treeWidget_DV130FamilySupport->setColumnWidth(2,120);
    ui->treeWidget_DV130FamilySupport->setColumnWidth(3,120);
    ui->treeWidget_DV130FamilySupport->setColumnWidth(4,120);
    ui->treeWidget_DV130FamilySupport->setColumnWidth(5,120);
    ui->treeWidget_DV130FamilySupport->setColumnWidth(6,120);
    ui->treeWidget_DV130FamilySupport->setHeaderLabels(QStringList() << "DESIGNATION" << "FULL NAME" << "GROSS/MO." << "DEDUCTIONS/MO." << "HARDSHIPS/MO." << "TANF/CAL WORKS" << "NET/MO.");
    AddRootDV130FamilySupport(str10, str11, str12, str13, str14, str15, str16);
    AddRootDV130FamilySupport(str17, str18, str19, str20, str21, str22, str23);
}

void MainWindow::LoadCaseOrdersCH110()
{
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

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
    QString etime;
    QString edate;

    int ca, cb, cc;

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.find("caseorders");
    xmlGet.findAndDescend("CH110");
    xmlGet.findAndDescend("stack1");
    xmlGet.findAndDescend("ConductOrders");
    xmlGet.find("CH110StatusConduct");
    ca = xmlGet.getInt();
    xmlGet.find("CH110NoContact");
    bool CH110NoContact = xmlGet.getBool();
    xmlGet.find("CH110NoHarass");
    bool CH110NoHarass = xmlGet.getBool();
    xmlGet.find("CH110NoLocate");
    bool CH110NoLocate = xmlGet.getBool();
    xmlGet.find("CH110NoContactOtherProtected");
    bool CH110NoContactOtherProtected = xmlGet.getBool();
    xmlGet.find("CH110ConductOtherOrder");
    bool CH110ConductOtherOrder = xmlGet.getBool();
    xmlGet.find("CH110ConductOtherOrderDetail");
    str1 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("StayAwayOrders");
    xmlGet.find("CH110StatusStayAway");
    cb = xmlGet.getInt();
    xmlGet.find("CH110StayAwayDistance");
    str2 = xmlGet.getString();
    xmlGet.find("CH110NoPerson");
    bool CH110NoPerson = xmlGet.getBool();
    xmlGet.find("CH110NoWork");
    bool CH110NoWork = xmlGet.getBool();
    xmlGet.find("CH110NoSchool");
    bool CH110NoSchool = xmlGet.getBool();
    xmlGet.find("CH110NoHome");
    bool CH110NoHome = xmlGet.getBool();
    xmlGet.find("CH110NoChildcare");
    bool CH110NoChildcare = xmlGet.getBool();
    xmlGet.find("CH110NoVehicle");
    bool CH110NoVehicle = xmlGet.getBool();
    xmlGet.find("CH110NoOtherProtected");
    bool CH110NoOtherProtected = xmlGet.getBool();
    xmlGet.find("CH110StayAwayOtherOrders");
    bool CH110StayAwayOtherOrders = xmlGet.getBool();
    xmlGet.find("CH110StayAwayOtherOrdersDetail");
    str3 = xmlGet.getString();
    xmlGet.findAndDescend("CH110OtherProtected");
    xmlGet.findAndDescend("OtherProtected1");
    xmlGet.find("entity");
    str4 = xmlGet.getString();
    xmlGet.find("fullname");
    str5 = xmlGet.getString();
    xmlGet.find("relationship");
    str6 = xmlGet.getString();
    xmlGet.find("household");
    str7 = xmlGet.getString();
    xmlGet.find("age");
    str8 = xmlGet.getString();
    xmlGet.find("sex");
    str9 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherProtected2");
    xmlGet.find("entity");
    str10 = xmlGet.getString();
    xmlGet.find("fullname");
    str11 = xmlGet.getString();
    xmlGet.find("relationship");
    str12 = xmlGet.getString();
    xmlGet.find("household");
    str13 = xmlGet.getString();
    xmlGet.find("age");
    str14 = xmlGet.getString();
    xmlGet.find("sex");
    str15 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("FireArmsOrders");
    xmlGet.find("CH110FireArm");
    bool CH110FireArm = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("Carpos");
    xmlGet.find("CH110CarposEntryClerk");
    bool CH110CarposEntryClerk = xmlGet.getBool();
    xmlGet.find("CH110CarposEntryCLET");
    bool CH110CarposEntryCLET = xmlGet.getBool();
    xmlGet.find("CH110CarposEntryProtected");
    bool CH110CarposEntryProtected = xmlGet.getBool();
    xmlGet.find("CH110ServiceFeeOrdered");
    bool CH110ServiceFeeOrdered = xmlGet.getBool();
    xmlGet.find("CH110ServiceFeeNotOrdered");
    bool CH110ServiceFeeNotOrdered = xmlGet.getBool();
    xmlGet.find("CH110ServiceFeeWaiveViolence");
    bool CH110ServiceFeeWaiveViolence = xmlGet.getBool();
    xmlGet.find("CH110ServiceFeeWaiver");
    bool CH110ServiceFeeWaiver = xmlGet.getBool();
    xmlGet.findAndDescend("CH110LawEnforcement");
    xmlGet.findAndDescend("LawEnforcement1");
    xmlGet.find("agency");
    str16 = xmlGet.getString();
    xmlGet.find("address");
    str17 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("LawEnforcement2");
    xmlGet.find("agency");
    str18 = xmlGet.getString();
    xmlGet.find("address");
    str19 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherOrders");
    xmlGet.find("CH110OtherStatusOrders");
    cc = xmlGet.getInt();
    xmlGet.find("CH110OtherOrdersDetail");
    str20 = xmlGet.getString();
    xmlGet.find("CH110OtherOrdersAttach");
    bool CH110OtherOrdersAttach = xmlGet.getBool();
    xmlGet.find("CH110Expiration");
    bool CH110Expiration = xmlGet.getBool();
    xmlGet.find("CH110ExpirationTime");
    etime = xmlGet.getString();
    xmlGet.find("CH110ExpirationDate");
    edate = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();

//Load CH110 Data
    ui->comboBox_CH110StatusConduct->setCurrentIndex(ca);  
    ui->checkBox_CH110NoContact->setChecked(CH110NoContact);
    ui->checkBox_CH110NoHarass->setChecked(CH110NoHarass);
    ui->checkBox_CH110NoLocate->setChecked(CH110NoLocate);
    ui->checkBox_CH110NoContactOtherProtected->setChecked(CH110NoContactOtherProtected);
    ui->checkBox_CH110ConductOtherOrder->setChecked(CH110ConductOtherOrder);
    ui->lineEdit_CH110ConductOtherOrderDetail->setText(str1);

    ui->comboBox_CH110StatusStayAway->setCurrentIndex(cb);
    ui->lineEdit_CH110StayAwayDistance->setText(str2);
    ui->checkBox_CH110NoPerson->setChecked(CH110NoPerson);
    ui->checkBox_CH110NoWork->setChecked(CH110NoWork);
    ui->checkBox_CH110NoSchool->setChecked(CH110NoSchool);
    ui->checkBox_CH110NoHome->setChecked(CH110NoHome);
    ui->checkBox_CH110NoChildcare->setChecked(CH110NoChildcare);
    ui->checkBox_CH110NoVehicle->setChecked(CH110NoVehicle);
    ui->checkBox_CH110NoOtherProtected->setChecked(CH110NoOtherProtected);
    ui->checkBox_CH110StayAwayOtherOrders->setChecked(CH110StayAwayOtherOrders);
    ui->textEdit_CH110StayAwayOtherOrdersDetail->setText(str3);

    ui->checkBox_CH110FireArm->setChecked(CH110FireArm);
    ui->comboBox_CH110OtherStatusOrders->setCurrentIndex(cc);
    ui->textEdit_CH110OtherOrdersDetail->setText(str20);
    ui->checkBox_CH110OtherOrdersAttach->setChecked(CH110OtherOrdersAttach);

    ui->radioButton_CH110CarposEntryClerk->setChecked(CH110CarposEntryClerk);
    ui->radioButton_CH110CarposEntryCLET->setChecked(CH110CarposEntryCLET);
    ui->radioButton_CH110CarposEntryProtected->setChecked(CH110CarposEntryProtected);
    ui->radioButton_CH110ServiceFeeOrdered->setChecked(CH110ServiceFeeOrdered);
    ui->radioButton_CH110ServiceFeeNotOrdered->setChecked(CH110ServiceFeeNotOrdered);
    ui->checkBox_CH110ServiceFeeWaiveViolence->setChecked(CH110ServiceFeeWaiveViolence);
    ui->checkBox_CH110ServiceFeeWaiver->setChecked(CH110ServiceFeeWaiver);

    ui->checkBox_CH110Expiration->setChecked(CH110Expiration);
    QTime expiretime = QTime::fromString(etime, "hh:mm:ss");
    ui->timeEdit_CH110ExpirationTime->setTime(expiretime);
    QDate expiredate = QDate::fromString(edate, "MM-dd-yyyy");
    ui->dateEdit_CH110ExpirationDate->setDisplayFormat("MMM-dd-yyyy");
    ui->dateEdit_CH110ExpirationDate->setDate(expiredate);

//CH110 Others Protected Table
        ui->treeWidget_CH110OthersProtected->setColumnCount(6);
        ui->treeWidget_CH110OthersProtected->setColumnWidth(0,90);
        ui->treeWidget_CH110OthersProtected->setColumnWidth(1,120);
        ui->treeWidget_CH110OthersProtected->setColumnWidth(2,180);
        ui->treeWidget_CH110OthersProtected->setColumnWidth(3,180);
        ui->treeWidget_CH110OthersProtected->setColumnWidth(4,90);
        ui->treeWidget_CH110OthersProtected->setColumnWidth(5,90);
        ui->treeWidget_CH110OthersProtected->setHeaderLabels(QStringList() << "ENTITY" << "FULL NAME" << "RELATION TO PROTECTED" << "HOUSEHOLD MEMBER" << "AGE" << "SEX");
        AddRootCH110OthersProtected(str4, str5, str6, str7, str8, str9);
        AddRootCH110OthersProtected(str10, str11, str12, str13, str14, str15);

//CH110 Law Enforcement Table
        ui->treeWidget_CH110LawEnforcement->setColumnCount(2);
        ui->treeWidget_CH110LawEnforcement->setColumnWidth(0,140);
        ui->treeWidget_CH110LawEnforcement->setColumnWidth(1,280);
        ui->treeWidget_CH110LawEnforcement->setHeaderLabels(QStringList() << "AGENCY" << "ADDRESS");
        AddRootCH110LawEnforcement(str16, str17);
        AddRootCH110LawEnforcement(str18, str19);
}

void MainWindow::LoadCaseOrdersCH130()
{
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

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
    QString str26;
    QString str27;
    QString str28;

    int ca, cb;

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.find("caseorders");
    xmlGet.findAndDescend("CH130");
    xmlGet.findAndDescend("stack1");
    xmlGet.find("CH130ServiceProvided");
    bool CH130ServiceProvided = xmlGet.getBool();
    xmlGet.find("CH130ServiceNotP1Provided");
    bool CH130ServiceNotP1Provided = xmlGet.getBool();
    xmlGet.findAndDescend("ConductOrders");
    xmlGet.find("CH130Conduct");
    bool CH130Conduct = xmlGet.getBool();
    xmlGet.find("CH130NoContact");
    bool CH130NoContact = xmlGet.getBool();
    xmlGet.find("CH130NoHarass");
    bool CH130NoHarass = xmlGet.getBool();
    xmlGet.find("CH130NoLocate");
    bool CH130NoLocate = xmlGet.getBool();
    xmlGet.find("CH130NoContactOtherProtected");
    bool CH130NoContactOtherProtected = xmlGet.getBool();
    xmlGet.find("CH130ConductOtherOrders");
    bool CH130ConductOtherOrders = xmlGet.getBool();
    xmlGet.find("CH130ConductOtherOrdersDetail");
    str1 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("StayAwayOrders");
    xmlGet.find("CH130StayAway");
    bool CH130StayAway = xmlGet.getBool();
    xmlGet.find("CH130StayAwayDistance");
    str2 = xmlGet.getString();
    xmlGet.find("CH130NoPerson");
    bool CH130NoPerson = xmlGet.getBool();
    xmlGet.find("CH130NoWork");
    bool CH130NoWork = xmlGet.getBool();
    xmlGet.find("CH130NoHome");
    bool CH130NoHome = xmlGet.getBool();
    xmlGet.find("CH130NoVehicle");
    bool CH130NoVehicle = xmlGet.getBool();
    xmlGet.find("CH130NoSchool");
    bool CH130NoSchool = xmlGet.getBool();
    xmlGet.find("CH130NoChildcare");
    bool CH130NoChildcare = xmlGet.getBool();
    xmlGet.find("CH130StayAwayOthersProtected");
    bool CH130StayAwayOthersProtected = xmlGet.getBool();
    xmlGet.find("CH130StayAwayOtherOrders");
    bool CH130StayAwayOtherOrders = xmlGet.getBool();
    xmlGet.find("CH130StayAwayOtherOrdersDetail");
    str3 = xmlGet.getString();
    xmlGet.findAndDescend("CH130OtherProtected");
    xmlGet.findAndDescend("OtherProtected1");
    xmlGet.find("entity");
    str4 = xmlGet.getString();
    xmlGet.find("fullname");
    str5 = xmlGet.getString();
    xmlGet.find("relationship");
    str6 = xmlGet.getString();
    xmlGet.find("household");
    str7 = xmlGet.getString();
    xmlGet.find("age");
    str8 = xmlGet.getString();
    xmlGet.find("sex");
    str9 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherProtected2");
    xmlGet.find("entity");
    str10 = xmlGet.getString();
    xmlGet.find("fullname");
    str11 = xmlGet.getString();
    xmlGet.find("relationship");
    str12 = xmlGet.getString();
    xmlGet.find("household");
    str13 = xmlGet.getString();
    xmlGet.find("age");
    str14 = xmlGet.getString();
    xmlGet.find("sex");
    str15 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("FireArmsOrders");
    xmlGet.find("CH130FireArms");
    bool CH130FireArms = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("Carpos");
    xmlGet.find("CH130CarposEntryClerk");
    bool CH130CarposEntryClerk = xmlGet.getBool();
    xmlGet.find("CH130CarposEntryCLET");
    bool CH130CarposEntryCLET = xmlGet.getBool();
    xmlGet.find("CH130CarposEntryProtected");
    bool CH130CarposEntryProtected = xmlGet.getBool();
    xmlGet.find("CH130ServiceFeeOrdered");
    bool CH130ServiceFeeOrdered = xmlGet.getBool();
    xmlGet.find("CH130ServiceFeeNotOrdered");
    bool CH130ServiceFeeNotOrdered = xmlGet.getBool();
    xmlGet.find("CH130ServiceFeeWaivedViolence");
    bool CH130ServiceFeeWaivedViolence = xmlGet.getBool();
    xmlGet.find("CH130ServiceFeeWaiver");
    bool CH130ServiceFeeWaiver = xmlGet.getBool();
    xmlGet.findAndDescend("CH130LawEnforcement");
    xmlGet.findAndDescend("LawEnforcement1");
    xmlGet.find("agency");
    str16 = xmlGet.getString();
    xmlGet.find("address");
    str17 = xmlGet.getString();
    xmlGet.findAndDescend("LawEnforcement2");
    xmlGet.findAndDescend("agency");
    str18 = xmlGet.getString();
    xmlGet.find("address");
    str19 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherOrders");
    xmlGet.find("CH130OtherOrders");
    bool CH130OtherOrders = xmlGet.getBool();
    xmlGet.find("CH130OtherOrdersDetail");
    str20 = xmlGet.getString();
    xmlGet.find("CH130NoExpire");
    bool CH130NoExpire = xmlGet.getBool();
    xmlGet.find("CH130Expiration");
    bool CH130Expiration = xmlGet.getBool();
    xmlGet.find("CH130ExpirationTime");
    str21 = xmlGet.getString();
    xmlGet.find("CH130ExpirationDate");
    str22 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("stack2");
    xmlGet.findAndDescend("AttorneyFees");
    xmlGet.find("CH130AttorneysFeesOrder");
    bool CH130AttorneysFeesOrder = xmlGet.getBool();
    xmlGet.find("CH130AttorneysFeesPaidBy");
    ca = xmlGet.getInt();
    xmlGet.find("CH130AttorneysFeesPaidTo");
    cb = xmlGet.getInt();
    xmlGet.find("CH130LawyersFeesPaid");
    bool CH130LawyersFeesPaid = xmlGet.getBool();
    xmlGet.find("CH130CourtCostsPaid");
    bool CH130CourtCostsPaid = xmlGet.getBool();
    xmlGet.findAndDescend("CH130Payments");
    xmlGet.findAndDescend("Payment1");
    xmlGet.find("item");
    str23 = xmlGet.getString();
    xmlGet.find("amount");
    str24 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("Payment2");
    xmlGet.find("item");
    str25 = xmlGet.getString();
    xmlGet.find("amount");
    str26 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("Payment3");
    xmlGet.find("item");
    str27 = xmlGet.getString();
    xmlGet.find("amount");
    str28 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();

//Load CH130 Order
    ui->radioButton_CH130ServiceProvided->setChecked(CH130ServiceProvided);
    ui->radioButton_CH130ServiceNotP1Provided->setChecked(CH130ServiceNotP1Provided);
    ui->checkBox_CH130Conduct->setChecked(CH130Conduct);
    ui->checkBox_CH130NoContact->setChecked(CH130NoContact);
    ui->checkBox_CH130NoHarass->setChecked(CH130NoHarass);
    ui->checkBox_CH130NoLocate->setChecked(CH130NoLocate);
    ui->checkBox_CH130NoContactOtherProtected->setChecked(CH130NoContactOtherProtected);
    ui->checkBox_CH130ConductOtherOrders->setChecked(CH130ConductOtherOrders);
    ui->lineEdit_CH130ConductOtherOrdersDetail->setText(str1);
    ui->checkBox_CH130StayAway->setChecked(CH130StayAway);
    ui->lineEdit_CH130StayAwayDistance->setText(str2);
    ui->checkBox_CH130NoPerson->setChecked(CH130NoPerson);
    ui->checkBox_CH130NoWork->setChecked(CH130NoWork);
    ui->checkBox_CH130NoHome->setChecked(CH130NoHome);
    ui->checkBox_CH130NoVehicle->setChecked(CH130NoVehicle);
    ui->checkBox_CH130NoSchool->setChecked(CH130NoSchool);
    ui->checkBox_CH130NoChildcare->setChecked(CH130NoChildcare);
    ui->checkBox_CH130StayAwayOthersProtected->setChecked(CH130StayAwayOthersProtected);
    ui->checkBox_CH130StayAwayOtherOrders->setChecked(CH130StayAwayOtherOrders);
    ui->textEdit_CH130StayAwayOtherDetail->setText(str3);
    ui->checkBox_CH130FireArms->setChecked(CH130FireArms);
    ui->radioButton_CH130CarposEntryClerk->setChecked( CH130CarposEntryClerk);
    ui->radioButton_CH130CarposEntryCLET->setChecked(CH130CarposEntryCLET);
    ui->radioButton_CH130CarposEntryProtected->setChecked(CH130CarposEntryProtected);
    ui->radioButton_CH130ServiceFeeOrdered->setChecked(CH130ServiceFeeOrdered);
    ui->radioButton_CH130ServiceFeeNotOrdered->setChecked(CH130ServiceFeeNotOrdered);
    ui->checkBox_CH130ServiceFeeWaivedViolence->setChecked(CH130ServiceFeeWaivedViolence);
    ui->checkBox_CH130ServiceFeeWaiver->setChecked(CH130ServiceFeeWaiver);
    ui->checkBox_CH130OtherOrders->setChecked(CH130OtherOrders);
    ui->textEdit_CH130therOrdersDetail->setText(str20);
    ui->checkBox_CH130NoExpire->setChecked(CH130NoExpire);
    ui->checkBox_CH130Expiration->setChecked(CH130Expiration);
    QTime expireCH130time = QTime::fromString(str21, "hh:mm:ss");
    ui->timeEdit_CH130ExpirationTime->setTime(expireCH130time);
    QDate expireCH130date = QDate::fromString(str22, "MM-dd-yyyy");
    ui->dateEdit_CH130ExpirationDate->setDisplayFormat("MMM-dd-yyyy");
    ui->dateEdit_CH130ExpirationDate->setDate(expireCH130date);

    ui->checkBox_CH130AttorneysFeesOrder->setChecked(CH130AttorneysFeesOrder);
    ui->comboBox_CH130AttorneyFeesPaidBy->setCurrentIndex(ca);
    ui->comboBox_CH130AttorneyFeesPaidTo->setCurrentIndex(cb);
    ui->checkBox_CH130LawyersFeesPaid->setChecked(CH130LawyersFeesPaid);
    ui->checkBox_CH130CourtCostsPaid->setChecked(CH130CourtCostsPaid);

    //CH130 Others Protected Table
        ui->treeWidget_CH130OthersProtected->setColumnCount(6);
        ui->treeWidget_CH130OthersProtected->setColumnWidth(0,90);
        ui->treeWidget_CH130OthersProtected->setColumnWidth(1,120);
        ui->treeWidget_CH130OthersProtected->setColumnWidth(2,180);
        ui->treeWidget_CH130OthersProtected->setColumnWidth(3,180);
        ui->treeWidget_CH130OthersProtected->setColumnWidth(4,90);
        ui->treeWidget_CH130OthersProtected->setColumnWidth(5,90);
        ui->treeWidget_CH130OthersProtected->setHeaderLabels(QStringList() << "ENTITY" << "FULL NAME" << "RELATION TO PROTECTED" << "HOUSEHOLD MEMBER" << "AGE" << "SEX");
        AddRootCH130OthersProtected(str4, str5, str6, str7, str8, str9);
        AddRootCH130OthersProtected(str10, str11, str12, str13, str14, str15);

    //CH130 Law Enforcement Table
        ui->treeWidget_CH130LawEnforcement->setColumnCount(2);
        ui->treeWidget_CH130LawEnforcement->setColumnWidth(0,140);
        ui->treeWidget_CH130LawEnforcement->setColumnWidth(1,280);
        ui->treeWidget_CH130LawEnforcement->setHeaderLabels(QStringList() << "AGENCY" << "ADDRESS");
        AddRootCH130LawEnforcement(str16, str17);
        AddRootCH130LawEnforcement(str18, str19);

//CH130 Law Enforcement Table
      ui->treeWidget_CH130Payments->setColumnCount(2);
      ui->treeWidget_CH130Payments->setColumnWidth(0,240);
      ui->treeWidget_CH130Payments->setColumnWidth(1,400);
      ui->treeWidget_CH130Payments->setHeaderLabels(QStringList() << "ITEM" << "AMOUNT");
      AddRootCH130Payments(str23, str24);
      AddRootCH130Payments(str25, str26);
      AddRootCH130Payments(str27, str28);
}

void MainWindow::LoadCaseOrdersEA110()
{
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

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
    int ea, eb, ec, ed;

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.find("caseorders");
    xmlGet.findAndDescend("EA110");
    xmlGet.find("EA110ElderlyPresent");
    bool EA110ElderlyPresent = xmlGet.getBool();
    xmlGet.find("EA110ElderlyProtectedName");
    str1 = xmlGet.getString();
    xmlGet.findAndDescend("ConductOrders");
    xmlGet.find("EA110ConductStatus");
    ea = xmlGet.getInt();
    xmlGet.find("EA110NoContact");
    bool EA110NoContact = xmlGet.getBool();
    xmlGet.find("EA110NoHarass");
    bool EA110NoHarass = xmlGet.getBool();
    xmlGet.find("EA110NoLocate");
    bool EA110NoLocate = xmlGet.getBool();
    xmlGet.find("EA110NoContactOtherProtected");
    bool EA110NoContactOtherProtected = xmlGet.getBool();
    xmlGet.find("EA110ConductOtherOrders");
    bool EA110ConductOtherOrders = xmlGet.getBool();
    xmlGet.find("EA110ConductOtherOrderDetail");
    str2 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("StayAwayOrders");
    xmlGet.find("EA110StayAwayStatus");
    eb = xmlGet.getInt();
    xmlGet.find("EA110StayAwayDistance");
    str3 = xmlGet.getString();
    xmlGet.find("EA110NoPerson");
    bool EA110NoPerson = xmlGet.getBool();
    xmlGet.find("EA110NoWork");
    bool EA110NoWork = xmlGet.getBool();
    xmlGet.find("EA110NoHome");
    bool EA110NoHome = xmlGet.getBool();
    xmlGet.find("EA110NoVehicle");
    bool EA110NoVehicle = xmlGet.getBool();
    xmlGet.find("EA110StayAwayOtherProtected");
    bool EA110StayAwayOtherProtected = xmlGet.getBool();
    xmlGet.find("EA110StayAwayOtherOrders");
    bool EA110StayAwayOtherOrders = xmlGet.getBool();
    xmlGet.find("EA110StayAwayOtherOrdersDetail");
    str4 = xmlGet.getString();
    xmlGet.findAndDescend("EA110OtherProtected");
    xmlGet.findAndDescend("OtherProtected1");
    xmlGet.find("entity");
    str5 = xmlGet.getString();
    xmlGet.find("fullname");
    str6 = xmlGet.getString();
    xmlGet.find("relationship");
    str7 = xmlGet.getString();
    xmlGet.find("household");
    str8 = xmlGet.getString();
    xmlGet.find("age");
    str9 = xmlGet.getString();
    xmlGet.find("sex");
    str10 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherProtected2");
    xmlGet.find("entity");
    str11 = xmlGet.getString();
    xmlGet.find("fullname");
    str12 = xmlGet.getString();
    xmlGet.find("relationship");
    str13 = xmlGet.getString();
    xmlGet.find("household");
    str14 = xmlGet.getString();
    xmlGet.find("age");
    str15 = xmlGet.getString();
    xmlGet.find("sex");
    str16 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("MoveOutOrders");
    xmlGet.find("EA110MoveOutStatus");
    ec = xmlGet.getInt();
    xmlGet.find("EA110MoveOutAddress");
    str17 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("FireArmsOrders");
    xmlGet.find("EA110FireArmsNotIssued");
    bool EA110FireArmsNotIssued = xmlGet.getBool();
    xmlGet.find("EA110FireArmsNoGuns");
    bool EA110FireArmsNoGuns = xmlGet.getBool();
    xmlGet.find("EA110FireArmsCourtInformed");
    bool EA110FireArmsCourtInformed = xmlGet.getBool();
    xmlGet.find("EA110FinancialAbuseOnly");
    bool EA110FinancialAbuseOnly = xmlGet.getBool();
    xmlGet.find("EA110FinancialAbuseNotSoley");
    bool EA110FinancialAbuseNotSoley = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("Carpos");
    xmlGet.find("EA110CarposEntryClerk");
    bool EA110CarposEntryClerk = xmlGet.getBool();
    xmlGet.find("EA110CarposEntryCLET");
    bool EA110CarposEntryCLET = xmlGet.getBool();
    xmlGet.find("EA110CarposEntryProtected");
    bool EA110CarposEntryProtected = xmlGet.getBool();
    xmlGet.find("EA110ServiceFeeOrdered");
    bool EA110ServiceFeeOrdered = xmlGet.getBool();
    xmlGet.find("EA110ServiceFeeNotOrdered");
    bool EA110ServiceFeeNotOrdered = xmlGet.getBool();
    xmlGet.find("EA110ServiceFeeWaiveViolence");
    bool EA110ServiceFeeWaiveViolence = xmlGet.getBool();
    xmlGet.find("EA110ServiceFeeWaiver");
    bool EA110ServiceFeeWaiver = xmlGet.getBool();
    xmlGet.findAndDescend("EA110LawEnforcement");
    xmlGet.findAndDescend("LawEnforcement1");
    xmlGet.find("agency");
    str18 = xmlGet.getString();
    xmlGet.find("address");
    str19 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("LawEnforcement2");
    xmlGet.find("agency");
    str20 = xmlGet.getString();
    xmlGet.find("address");
    str21 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherOrders");
    xmlGet.find("EA110OtherOrderStatus");
    ed = xmlGet.getInt();
    xmlGet.find("EA110OtherOrderDetail");
    str22 = xmlGet.getString();
    xmlGet.find("EA110Expiration");
    bool EA110Expiration = xmlGet.getBool();
    xmlGet.find("EA110ExpirationTime");
    str23 = xmlGet.getString();
    xmlGet.find("EA110ExpirationDate");
    str24 = xmlGet.getString();
    xmlGet.rise();

//Load EA110 Screen
    ui->checkBox_EA110ElderlyPresent->setChecked(EA110ElderlyPresent);
    ui->lineEdit_EA110ElderlyProtectedName->setText(str1);

    ui->comboBox_EA110StatusConduct->setCurrentIndex(ea);
    ui->checkBox_EA110NoContact->setChecked(EA110NoContact);
    ui->checkBox_EA110NoHarass->setChecked(EA110NoHarass);
    ui->checkBox_EA110NoLocate->setChecked(EA110NoLocate);
    ui->checkBox_EA110NoContactOtherProtected->setChecked(EA110NoContactOtherProtected);
    ui->checkBox_EA110ConductOtherOrders->setChecked(EA110ConductOtherOrders);
    ui->lineEdit_EA110ConductOtherOrdersDetail->setText(str2);

    ui->comboBox_EA110StatusStayAway->setCurrentIndex(ea);
    ui->lineEdit_EA110StayAwayDistance->setText(str3);
    ui->checkBox_EA110NoPerson->setChecked(EA110NoPerson);
    ui->checkBox_EA110NoWork->setChecked(EA110NoWork);
    ui->checkBox_EA110NoHome->setChecked(EA110NoHome);
    ui->checkBox_EA110NoVehicle->setChecked(EA110NoVehicle);
    ui->checkBox_EA110StayAwayOtherProtected->setChecked(EA110StayAwayOtherProtected);
    ui->checkBox_EA110StayAwayOtherOrders->setChecked(EA110StayAwayOtherOrders);
    ui->textEdit_EA110StayAwayOtherOrdersDetail->setText(str4);

    ui->comboBox_EA110StatusMoveOut->setCurrentIndex(ea);
    ui->lineEdit_EA110MoveOutAddress->setText(str17);
    ui->checkBox_EA110FireArmsNotIssued->setChecked(EA110FireArmsNotIssued);
    ui->checkBox_EA110FireArmsNoGuns->setChecked(EA110FireArmsNoGuns);
    ui->checkBox_EA110FireArmsCourtInformed->setChecked(EA110FireArmsCourtInformed);
    ui->checkBox_EA110FinancialAbuseOnly->setChecked(EA110FinancialAbuseOnly);
    ui->checkBox_EA110FinancialAbuseNotSoley->setChecked(EA110FinancialAbuseNotSoley);
    ui->radioButton_EA110CarposEntryClerk->setChecked(EA110CarposEntryClerk);
    ui->radioButton_EA110CarposEntryCLET->setChecked(EA110CarposEntryCLET);
    ui->radioButton_EA110CarposEntryProtected->setChecked(EA110CarposEntryProtected);
    ui->radioButton_EA110ServiceFeeOrdered->setChecked(EA110ServiceFeeOrdered);
    ui->radioButton_EA110ServiceFeeNotOrdered->setChecked(EA110ServiceFeeNotOrdered);
    ui->checkBox_EA110ServiceFeeWaiveViolence->setChecked(EA110ServiceFeeWaiveViolence);
    ui->checkBox_EA110ServiceFeeWaiver->setChecked(EA110ServiceFeeWaiver);

    ui->comboBox_EA110StatusOtherOrders->setCurrentIndex(ed);
    ui->lineEdit_EA110OtherOrdersDetail->setText(str22);
    ui->checkBox_EA110Expiration->setChecked(EA110Expiration);
    QTime expiretimeEA110 = QTime::fromString(str23, "hh:mm:SS");
    ui->timeEdit_EA110ExpireTime->setTime(expiretimeEA110);
    QDate expiredateEA110 = QDate::fromString(str24, "MM-dd-yyyy");
    ui->dateEdit_EA110ExpireDate->setDisplayFormat("MMM-dd-yyyy");
    ui->dateEdit_EA110ExpireDate->setDate(expiredateEA110);

//EA110 Others Protected Table
    ui->treeWidget_EA110OthersProtected->setColumnCount(6);
    ui->treeWidget_EA110OthersProtected->setColumnWidth(0,90);
    ui->treeWidget_EA110OthersProtected->setColumnWidth(1,120);
    ui->treeWidget_EA110OthersProtected->setColumnWidth(2,180);
    ui->treeWidget_EA110OthersProtected->setColumnWidth(3,180);
    ui->treeWidget_EA110OthersProtected->setColumnWidth(4,90);
    ui->treeWidget_EA110OthersProtected->setColumnWidth(5,90);
    ui->treeWidget_EA110OthersProtected->setHeaderLabels(QStringList() << "ENTITY" << "FULL NAME" << "RELATION TO PROTECTED" << "HOUSEHOLD MEMBER" << "AGE" << "SEX");
    AddRootEA110OthersProtected(str5, str6, str7, str8, str9, str10);
    AddRootEA110OthersProtected(str11, str12, str13, str14, str15, str16);

//EA110 Law Enforcement Table
    ui->treeWidget_EA110LawEnforcement->setColumnCount(2);
    ui->treeWidget_EA110LawEnforcement->setColumnWidth(0,140);
    ui->treeWidget_EA110LawEnforcement->setColumnWidth(1,280);
    ui->treeWidget_EA110LawEnforcement->setHeaderLabels(QStringList() << "AGENCY" << "ADDRESS");
    AddRootEA110LawEnforcement(str18, str19);
    AddRootEA110LawEnforcement(str20, str21);
}

void MainWindow::LoadCaseOrdersEA130()
{
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

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

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.find("caseorders");
    xmlGet.findAndDescend("EA130");
    xmlGet.find("EA130ElderlyPresent");
    bool EA130ElderlyPresent = xmlGet.getBool();
    xmlGet.find("EA130ElderlyProtectedName");
    str1 = xmlGet.getString();
    xmlGet.find("EA130ServiceProvided");
    bool EA130ServiceProvided = xmlGet.getBool();
    xmlGet.find("EA130ServiceNotP1Provided");
    bool EA130ServiceNotP1Provided = xmlGet.getBool();
    xmlGet.findAndDescend("ConductOrders");
    xmlGet.find("EA130Conduct");
    bool EA130Conduct = xmlGet.getBool();
    xmlGet.find("EA130NoContact");
    bool EA130NoContact = xmlGet.getBool();
    xmlGet.find("EA130NoHarass");
    bool EA130NoHarass = xmlGet.getBool();
    xmlGet.find("EA130NoLocate");
    bool EA130NoLocate = xmlGet.getBool();
    xmlGet.find("EA130NoContactOtherProtected");
    bool EA130NoContactOtherProtected = xmlGet.getBool();
    xmlGet.find("EA130ConductOtherOrders");
    bool EA130ConductOtherOrders = xmlGet.getBool();
    xmlGet.find("EA130ConductOtherOrderDetail");
    str2 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("StayAwayOrders");
    xmlGet.find("EA130StayAway");
    bool EA130StayAway = xmlGet.getBool();
    xmlGet.find("EA130StayAwayDistance");
    str3 = xmlGet.getString();
    xmlGet.find("EA130NoPerson");
    bool EA130NoPerson = xmlGet.getBool();
    xmlGet.find("EA130NoWork");
    bool EA130NoWork = xmlGet.getBool();
    xmlGet.find("EA130NoHome");
    bool EA130NoHome = xmlGet.getBool();
    xmlGet.find("EA130NoVehicle");
    bool EA130NoVehicle = xmlGet.getBool();
    xmlGet.find("EA130NoSchool");
    bool EA130NoSchool = xmlGet.getBool();
    xmlGet.find("EA130NoChildcare");
    bool EA130NoChildcare = xmlGet.getBool();
    xmlGet.find("EA130StayAwayOtherProtected");
    bool EA130StayAwayOtherProtected = xmlGet.getBool();
    xmlGet.find("EA130StayAwayOtherOrders");
    bool EA130StayAwayOtherOrders = xmlGet.getBool();
    xmlGet.find("EA130StayAwayOtherOrdersDetail");
    str4 = xmlGet.getString();
    xmlGet.findAndDescend("EA130OtherProtected");
    xmlGet.findAndDescend("OtherProtected1");
    xmlGet.find("entity");
    str5 = xmlGet.getString();
    xmlGet.find("fullname");
    str6 = xmlGet.getString();
    xmlGet.find("relationship");
    str7 = xmlGet.getString();
    xmlGet.find("household");
    str8 = xmlGet.getString();
    xmlGet.find("age");
    str9 = xmlGet.getString();
    xmlGet.find("sex");
    str10 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherProtected2");
    xmlGet.find("entity");
    str11 = xmlGet.getString();
    xmlGet.find("fullname");
    str12 = xmlGet.getString();
    xmlGet.find("relationship");
    str13 = xmlGet.getString();
    xmlGet.find("household");
    str14 = xmlGet.getString();
    xmlGet.find("age");
    str15 = xmlGet.getString();
    xmlGet.find("sex");
    str16 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("MoveOutOrders");
    xmlGet.find("EA130MoveOut");
    bool EA130MoveOut = xmlGet.getBool();
    xmlGet.find("EA130MoveOutAddress");
    str17 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("FireArmsOrders");
    xmlGet.find("EA130FireArms");
    bool EA130FireArms = xmlGet.getBool();
    xmlGet.find("EA130FireArmsNotIssued");
    bool EA130FireArmsNotIssued = xmlGet.getBool();
    xmlGet.find("EA130FireArmsNoGuns");
    bool EA130FireArmsNoGuns = xmlGet.getBool();
    xmlGet.find("EA130FireArmsCourtInformed");
    bool EA130FireArmsCourtInformed = xmlGet.getBool();
    xmlGet.find("EA130FinancialAbuseOnly");
    bool EA130FinancialAbuseOnly = xmlGet.getBool();
    xmlGet.find("EA130FinancialAbuseNotSoley");
    bool EA130FinancialAbuseNotSoley = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("Carpos");
    xmlGet.find("EA130CarposEntryClerk");
    bool EA130CarposEntryClerk = xmlGet.getBool();
    xmlGet.find("EA130CarposEntryCLET");
    bool EA130CarposEntryCLET = xmlGet.getBool();
    xmlGet.find("EA130CarposEntryProtected");
    bool EA130CarposEntryProtected = xmlGet.getBool();
    xmlGet.find("EA130ServiceFeeOrdered");
    bool EA130ServiceFeeOrdered = xmlGet.getBool();
    xmlGet.find("EA130ServiceFeeNotOrdered");
    bool EA130ServiceFeeNotOrdered = xmlGet.getBool();
    xmlGet.find("EA130ServiceFeeWaiveViolence");
    bool EA130ServiceFeeWaiveViolence = xmlGet.getBool();
    xmlGet.find("EA130ServiceFeeWaiver");
    bool EA130ServiceFeeWaiver = xmlGet.getBool();
    xmlGet.findAndDescend("EA130LawEnforcement");
    xmlGet.findAndDescend("LawEnforcement1");
    xmlGet.find("agency");
    str18 = xmlGet.getString();
    xmlGet.find("address");
    str19 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("LawEnforcement2");
    xmlGet.find("agency");
    str20 = xmlGet.getString();
    xmlGet.find("address");
    str21 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.findAndDescend("OtherOrders");
    xmlGet.find("EA130OtherOrders");
    bool EA130OtherOrders = xmlGet.getBool();
    xmlGet.find("EA130OtherOrderDetail");
    str22 = xmlGet.getString();
    xmlGet.find("EA130NoExpire");
    bool EA130NoExpire = xmlGet.getBool();
    xmlGet.find("EA130Expiration");
    bool EA130Expiration = xmlGet.getBool();
    xmlGet.find("EA130ExpirationTime");
    str23 = xmlGet.getString();
    xmlGet.find("EA130ExpirationDate");
    str24 = xmlGet.getString();
    xmlGet.rise();

    ui->checkBox_EA130ElderlyPresent->setChecked(EA130ElderlyPresent);
    ui->lineEdit_EA130ElderlyProtectedName->setText(str1);
    ui->radioButton_EA130ServiceProvided->setChecked(EA130ServiceProvided);
    ui->radioButton_EA130ServiceNotP1Provided->setChecked(EA130ServiceNotP1Provided);

    ui->checkBox_EA130Conduct->setChecked(EA130Conduct);
    ui->checkBox_EA130NoContact->setChecked(EA130NoContact);
    ui->checkBox_EA130NoHarass->setChecked(EA130NoHarass);
    ui->checkBox_EA130NoLocate->setChecked(EA130NoLocate);
    ui->checkBox_EA130NoContactOtherProtected->setChecked(EA130NoContactOtherProtected);
    ui->checkBox_EA130ConductOtherOrder->setChecked(EA130ConductOtherOrders);
    ui->lineEdit_EA130ConductOtherOrderDetail->setText(str2);

    ui->checkBox_EA130StayAway->setChecked(EA130StayAway);
    ui->lineEdit_EA130StayAwayDistance->setText(str3);
    ui->checkBox_EA130NoPerson->setChecked(EA130NoPerson);
    ui->checkBox_EA130NoWork->setChecked(EA130NoWork);
    ui->checkBox_EA130NoHome->setChecked(EA130NoHome);
    ui->checkBox_EA130NoVehicle->setChecked(EA130NoVehicle);
    ui->checkBox_EA130NoSchool->setChecked(EA130NoSchool);
    ui->checkBox_EA130NoChildcare->setChecked(EA130NoChildcare);
    ui->checkBox_EA130StayAwayOtherProtected->setChecked(EA130StayAwayOtherProtected);
    ui->checkBox_EA130StayAwayOtherOrders->setChecked(EA130StayAwayOtherOrders);
    ui->textEdit_EA130StayAwayOtherOrdersDetail->setText(str4);
    ui->checkBox_EA130MoveOut->setChecked(EA130MoveOut);
    ui->lineEdit_EA130MoveOutAddress->setText(str17);
    ui->checkBox_EA130FireArms->setChecked(EA130FireArms);
    ui->checkBox_EA130FireArmsNotIssued->setChecked(EA130FireArmsNotIssued);
    ui->checkBox_EA130FireArmsNoGuns->setChecked(EA130FireArmsNoGuns);
    ui->checkBox_EA130FireArmsCourtInformed->setChecked(EA130FireArmsCourtInformed);
    ui->checkBox_EA130FinancialAbuseOnly->setChecked(EA130FinancialAbuseOnly);
    ui->checkBox_EA130FinancialAbuseNotSoley->setChecked(EA130FinancialAbuseNotSoley);
    ui->radioButton_EA130CarposEntryClerk->setChecked(EA130CarposEntryClerk);
    ui->radioButton_EA130CarposEntryCLET->setChecked(EA130CarposEntryCLET);
    ui->radioButton_EA130CarposEntryProtected->setChecked(EA130CarposEntryProtected);
    ui->radioButton_EA130ServiceFeeOrdered->setChecked(EA130ServiceFeeOrdered);
    ui->radioButton_EA130ServiceFeeNotOrdered->setChecked(EA130ServiceFeeNotOrdered);
    ui->checkBox_EA130ServiceFeeWaiveViolence->setChecked(EA130ServiceFeeWaiveViolence);
    ui->checkBox_EA130ServiceFeeWaiver->setChecked(EA130ServiceFeeWaiver);

    ui->checkBox_EA130OtherOrders->setChecked(EA130OtherOrders);
    ui->lineEdit_EA130OtherOrdersDetail->setText(str22);
    ui->checkBox_EA130NoExpire->setChecked(EA130NoExpire);
    ui->checkBox_EA130Expiration->setChecked(EA130Expiration);
    QTime expiretimeEA130 = QTime::fromString(str23, "hh:mm:SS");
    ui->timeEdit_EA130ExpireTime->setTime(expiretimeEA130);
    QDate expiredateEA130 = QDate::fromString(str24, "MM-dd-yyyy");
    ui->dateEdit_EA130ExpireDate->setDisplayFormat("MMM-dd-yyyy");
    ui->dateEdit_EA130ExpireDate->setDate(expiredateEA130);

    //EA130 Others Protected Table
        ui->treeWidget_EA130OthersProtected->setColumnCount(6);
        ui->treeWidget_EA130OthersProtected->setColumnWidth(0,90);
        ui->treeWidget_EA130OthersProtected->setColumnWidth(1,120);
        ui->treeWidget_EA130OthersProtected->setColumnWidth(2,180);
        ui->treeWidget_EA130OthersProtected->setColumnWidth(3,180);
        ui->treeWidget_EA130OthersProtected->setColumnWidth(4,90);
        ui->treeWidget_EA130OthersProtected->setColumnWidth(5,90);
        ui->treeWidget_EA130OthersProtected->setHeaderLabels(QStringList() << "ENTITY" << "FULL NAME" << "RELATION TO PROTECTED" << "HOUSEHOLD MEMBER" << "AGE" << "SEX");
        AddRootEA130OthersProtected(str5, str6, str7, str8, str9, str10);
        AddRootEA130OthersProtected(str11, str12, str13, str14, str15, str16);

    //EA110 Law Enforcement Table
        ui->treeWidget_EA130LawEnforcement->setColumnCount(2);
        ui->treeWidget_EA130LawEnforcement->setColumnWidth(0,140);
        ui->treeWidget_EA130LawEnforcement->setColumnWidth(1,280);
        ui->treeWidget_EA130LawEnforcement->setHeaderLabels(QStringList() << "AGENCY" << "ADDRESS");
        AddRootEA130LawEnforcement(str18, str19);
        AddRootEA130LawEnforcement(str20, str21);
}

void MainWindow::LoadCaseOrdersFL344()
{
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

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

    int pa;

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.findAndDescend("caseorders");
    xmlGet.findAndDescend("FL344");
    xmlGet.findAndDescend("PropertyControl");
    xmlGet.find("FL344PropertyControlOrder");
    bool FL344PropertyControlOrder = xmlGet.getBool();
    xmlGet.findAndDescend("FL344PropertyControlList");
    xmlGet.findAndDescend("item1");
    xmlGet.find("item");
    str1 = xmlGet.getString();
    xmlGet.find("propertygivento");
    str2 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("item2");
    xmlGet.find("item");
    str3 = xmlGet.getString();
    xmlGet.find("propertygivento");
    str4 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("item3");
    xmlGet.find("item");
    str5 = xmlGet.getString();
    xmlGet.find("propertygivento");
    str6 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("FL344PropertyControlAttachments");
    bool FL344PropertyControlAttachments = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("DebtPayment");
    xmlGet.find("FL344DebtPaymentOrders");
    bool FL344DebtPaymentOrders = xmlGet.getBool();
    xmlGet.findAndDescend("FL344DebtPaymentList");
    xmlGet.findAndDescend("item1");
    xmlGet.find("totaldebt");
    str7 = xmlGet.getString();
    xmlGet.find("debtpayment");
    str8 = xmlGet.getString();
    xmlGet.find("debtpaidby");
    str9 = xmlGet.getString();
    xmlGet.find("debtpaidto");
    str10 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("item2");
    xmlGet.find("totaldebt");
    str11 = xmlGet.getString();
    xmlGet.find("debtpayment");
    str12 = xmlGet.getString();
    xmlGet.find("debtpaidby");
    str13 = xmlGet.getString();
    xmlGet.find("debtpaidto");
    str14 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.find("FL344DebtPaymentAttachments");
    bool FL344DebtPaymentAttachments = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.findAndDescend("FL344PropertyRestraint");
    xmlGet.find("FL344PropertyRestrainedParty");
    pa = xmlGet.getInt();
    xmlGet.find("FL344NoTransfer");
    bool FL344NoTransfer = xmlGet.getBool();
    xmlGet.find("FL344NoCancel");
    bool FL344NoCancel = xmlGet.getBool();
    xmlGet.find("FL344NoDebt");
    bool FL344NoDebt = xmlGet.getBool();
    xmlGet.find("FL344NoticeToOtherParty");
    bool FL344NoticeToOtherParty = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.find("FL344TemporaryOrders");
    bool FL344TemporaryOrders = xmlGet.getBool();
    xmlGet.find("FL344OtherOrders");
    bool FL344OtherOrders = xmlGet.getBool();
    xmlGet.find("FL344OtherOrdersDetail");
    str15 = xmlGet.getString();
    xmlGet.rise();

    ui->checkBox_FL344PropertyControlOrder->setChecked(FL344PropertyControlOrder);
    ui->checkBox_FL344PropertyControlAttachments->setChecked(FL344PropertyControlAttachments);
    ui->checkBox_FL344DebtPaymentOrder->setChecked(FL344DebtPaymentOrders);
    ui->checkBox_FL344DebtPaymentAttachments->setChecked(FL344DebtPaymentAttachments);
    ui->comboBox_FL344PropertyRestrainedParty->setCurrentIndex(pa);
    ui->checkBox_FL344NoTransfer->setChecked(FL344NoTransfer);
    ui->checkBox_FL344NoCancel->setChecked(FL344NoCancel);
    ui->checkBox_FL344NoDebt->setChecked(FL344NoDebt);
    ui->checkBox_FL344NoticeToOtherParty->setChecked(FL344NoticeToOtherParty);
    ui->checkBox_FL344TemporaryOrder->setChecked(FL344TemporaryOrders);
    ui->checkBox_FL344OtherOrders->setChecked(FL344OtherOrders);
    ui->textEdit_FL344OtherOrdersDetail->setText(str15);

//FL344 PropertyContol
     ui->treeWidget_FL344PropertyControl->setColumnCount(2);
     ui->treeWidget_FL344PropertyControl->setColumnWidth(0,200);
     ui->treeWidget_FL344PropertyControl->setColumnWidth(1,500);
     ui->treeWidget_FL344PropertyControl->setHeaderLabels(QStringList() << "PROPERTY ITEM" << "PROPERTY GIVEN TO");
     AddRootFL344Property(str1, str2);
     AddRootFL344Property(str3, str4);
     AddRootFL344Property(str5, str6);
//FL344 Debt Table
     ui->treeWidget_FL344Debt->setColumnCount(4);
     ui->treeWidget_FL344Debt->setColumnWidth(0,150);
     ui->treeWidget_FL344Debt->setColumnWidth(1,150);
     ui->treeWidget_FL344Debt->setColumnWidth(2,240);
     ui->treeWidget_FL344Debt->setColumnWidth(3,240);
     ui->treeWidget_FL344Debt->setHeaderLabels(QStringList() << "TOTAL DEBT" << "DEBT PAYMENT" << "DEBT PAID BY" << "DEBT PAID TO");
     AddRootFL344DebtPayment(str7, str8, str9, str10);
     AddRootFL344DebtPayment(str11, str12, str13, str14);
}


void MainWindow::LoadCaseSummaryFL340()
{
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

    QString str1;
    QString str2;
    QString str3;
    QString motiondate;
    int sa, sb, sc, sd, se, sf, sg;

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.findAndDescend("caseorders");
    xmlGet.findAndDescend("FL340");
    xmlGet.findAndDescend("CourtOrderSummary");
    xmlGet.find("FL340ChildCustodyForm");
    sa = xmlGet.getInt();
    xmlGet.find("FL340ChildCustodyForm");
    sb = xmlGet.getInt();
    xmlGet.find("FL340ChildSupportForm");
    sc = xmlGet.getInt();
    xmlGet.find("FL340PropertyOrdersForm");
    sd = xmlGet.getInt();
    xmlGet.find("FL340AttorneysFeesForm");
    se = xmlGet.getInt();
    xmlGet.find("FL340OtherOrders");
    sf = xmlGet.getInt();
    xmlGet.find("FL340OtherOrdersDescribe");
    str1 = xmlGet.getString();
    xmlGet.rise();
    xmlGet.findAndDescend("ShowCauseMotion");
    xmlGet.find("FL340MotionDate");
    motiondate = xmlGet.getString();
    xmlGet.find("FL340MotionParty");
    sg = xmlGet.getInt();
    xmlGet.find("FL340ThirdPartyName");
    str2 = xmlGet.getString();
    xmlGet.find("FL340ThirdPartyDescription");
    str3 = xmlGet.getString();
    xmlGet.find("FL340ThirdPartyPresent");
    bool FL340ThirdPartyPresent = xmlGet.getBool();
    xmlGet.find("FL340ThirdPartySworn");
    bool FL340ThirdPartySworn = xmlGet.getBool();
    xmlGet.find("FL340ThirdPartyAttorney");
    bool FL340ThirdPartyAttorney = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.rise();

    ui->comboBox_FL340ChildCustodyForm->setCurrentIndex(sa);    
    ui->comboBox_FL340ChildSupportForm->setCurrentIndex(sb);   
    ui->comboBox_FL340FamilySupportForm->setCurrentIndex(sc);  
    ui->comboBox_FL340PropertyForm->setCurrentIndex(sd);    
    ui->comboBox_FL340AttorneysFeesForm->setCurrentIndex(sf);
    ui->comboBox_FL340OtherOrders->setCurrentIndex(sd);
    ui->lineEdit_FL340OtherOrdersDetail->setText(str1);

    QDate motionFL340date = QDate::fromString(motiondate, "MM-dd-yyyy");
    ui->dateEdit_FL340MotionFileDate->setDisplayFormat("MMM-dd-yyyy");
    ui->dateEdit_FL340MotionFileDate->setDate(motionFL340date);

    ui->comboBox_FL340MotionParty->setCurrentIndex(sg);
    ui->lineEdit_FL340ThirdPartyName->setText(str2);
    ui->lineEdit_FL340ThirdPartyDescription->setText(str3);
    ui->checkBox_FL340ThirdPartyPresent->setChecked(FL340ThirdPartyPresent);
    ui->checkBox_FL340ThirdPartySworn->setChecked(FL340ThirdPartySworn);
    ui->checkBox_FL340ThirdPartyAttorney->setChecked(FL340ThirdPartyAttorney);
}

void MainWindow::LoadCaseFindingFL341()
{
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

    QString str1;
    QString str2;
    int ta;

    QXmlGet xmlGet;
    xmlGet.load(loadfile2);
    xmlGet.findAndDescend("caseorders");
    xmlGet.findAndDescend("FL341");
    xmlGet.findAndDescend("CourtFindings");
    xmlGet.find("FL341CourtFindingsParty");
    ta = xmlGet.getInt();
    xmlGet.find("FL341FindingsChildAbduction");
    bool FL341FindingsChildAbduction = xmlGet.getBool();
    xmlGet.find("FL341FindingsChildSexAbuse");
    bool FL341FindingsChildSexAbuse = xmlGet.getBool();
    xmlGet.find("FL341FindingsChildPhysicalAbuse");
    bool FL341FindingsChildPhysicalAbuse = xmlGet.getBool();
    xmlGet.find("FL341FindingsChildDomesticViolence");
    bool FL341FindingsChildDomesticViolence = xmlGet.getBool();
    xmlGet.find("FL341FindingsChildDrugAbuse");
    bool FL341FindingsChildDrugAbuse = xmlGet.getBool();
    xmlGet.find("FL341FindingsChildAlcoholAbuse");
    bool FL341FindingsChildAlcoholAbuse = xmlGet.getBool();
    xmlGet.find("FL341FindingsChildNeglect");
    bool FL341FindingsChildNeglect = xmlGet.getBool();
    xmlGet.find("FL341FindingsOther");
    bool FL341FindingsOther = xmlGet.getBool();
    xmlGet.find("FL341FindingsSpecify");
    str1 = xmlGet.getString();
    xmlGet.find("FL341FindingsAddSpecify");
    str2 = xmlGet.getString();
    xmlGet.find("FL341FindingsDisputePetitioner");
    bool FL341FindingsDisputePetitioner = xmlGet.getBool();
    xmlGet.find("FL341FindingsDisputeRespondent");
    bool FL341FindingsDisputeRespondent = xmlGet.getBool();
    xmlGet.find("FL341FindingsForPetitioner");
    bool FL341FindingsForPetitioner = xmlGet.getBool();
    xmlGet.find("FL341FindingsForRespondent");
    bool FL341FindingsForRespondent = xmlGet.getBool();
    xmlGet.rise();
    xmlGet.rise();
    xmlGet.rise();

    ui->comboBox_FL341CourtFindingsParty->setCurrentIndex(ta);
    ui->checkBox_FL341FindingsChildAbduction->setChecked(FL341FindingsChildAbduction);
    ui->checkBox_FL341FindingsChildSexAbuse->setChecked(FL341FindingsChildSexAbuse);
    ui->checkBox_FL341FindingsChildPhysicalAbuse->setChecked(FL341FindingsChildPhysicalAbuse);
    ui->checkBox_FL341FindingsChildDomesticViolence->setChecked(FL341FindingsChildDomesticViolence);
    ui->checkBox_FL341FindingsChildDrugAbuse->setChecked(FL341FindingsChildDrugAbuse);
    ui->checkBox_FL341FindingsChildAlcoholAbuse->setChecked(FL341FindingsChildAlcoholAbuse);
    ui->checkBox_FL341FindingsChildNeglect->setChecked(FL341FindingsChildNeglect);
    ui->checkBox_FL341FindingsOther->setChecked(FL341FindingsOther);
    ui->lineEdit_FL341FindingsSpecify->setText(str1);
    ui->lineEdit_FL341FindingsAddSpecify->setText(str2);
    ui->checkBox_FL341FindingsDisputePetitioner->setChecked(FL341FindingsDisputePetitioner);
    ui->checkBox_FL341FindingsDisputeRespondent->setChecked(FL341FindingsDisputeRespondent);
    ui->checkBox_FL341FindingsForPetitioner->setChecked(FL341FindingsForPetitioner);
    ui->checkBox_FL341FindingsForRespondent->setChecked(FL341FindingsForRespondent);
}


// File Controls

void MainWindow::on_listWidget_listCaseRecord_itemSelectionChanged()
{
    ResetRecordTables();
    LoadCaseRecord();
}

void MainWindow::on_listWidget_caseOrderList_itemSelectionChanged()
{
    ResetOrderTables();
    LoadCaseHeader();
    LoadCaseOrdersDV110();
    LoadCaseOrdersDV130();
    LoadCaseOrdersCH110();
    LoadCaseOrdersCH130();
    LoadCaseOrdersEA110();
    LoadCaseOrdersEA130();
    LoadCaseOrdersFL344();
    LoadCaseSummaryFL340();
    LoadCaseFindingFL341();
    UnsignCase();
}


void MainWindow::UnsignCase()
{
//get caseID Open File
    QString orderid;
    orderid = ui->listWidget_caseOrderList->currentItem()->text();
    QStringList orderfile;
    orderfile << "/users/jamesreid/caseorders/" << orderid << "_order.xml";
    QString loadfile2 = orderfile.join("");

    int page, edit;

     QXmlGet xmlGet;
     xmlGet.load(loadfile2);
     xmlGet.findAndDescend("caseorders");
     xmlGet.findAndDescend("caseheader");
     xmlGet.find("caseComplete");
     page = xmlGet.getInt();
     xmlGet.find("caseEdit");
     edit = xmlGet.getInt();

     ui->stackedWidget_courtOrderEntry->setCurrentIndex(page);
     ui->listWidget_Orders_Stack->setCurrentRow(edit);
}


//DEMO CODE ONLY
void MainWindow::on_toolButton_previousDocket_clicked()
{
    ui->listWidget_caseOrderList->clear();
    ui->listWidget_caseOrderList->addItem("22-1212");
    ui->listWidget_caseOrderList->addItem("22-1213");
    ui->listWidget_caseOrderList->addItem("22-1234");
    ui->listWidget_caseOrderList->addItem("22-1267");
    ui->toolButton_nextDocket->setEnabled(true);
    ui->toolButton_currentDocket->setEnabled(true);
    ui->toolButton_previousDocket->setEnabled(false);
    int docket;
    docket = ui->listWidget_caseOrderList->count();
    ui->label_totalCases->setNum(docket);
    ui->label_totalCasesHeard->setNum(3);
    ui->label_ordersDate->setText("Jul 22 2013");
}

void MainWindow::on_toolButton_nextDocket_clicked()
{
    ui->listWidget_caseOrderList->clear();
    ui->listWidget_caseOrderList->addItem("22-1251");
    ui->listWidget_caseOrderList->addItem("22-1267");
    ui->listWidget_caseOrderList->addItem("22-1284");
    ui->listWidget_caseOrderList->addItem("22-1200");
    ui->toolButton_nextDocket->setEnabled(false);
    ui->toolButton_currentDocket->setEnabled(false);
    ui->toolButton_previousDocket->setEnabled(true);
    int docket;
    docket = ui->listWidget_caseOrderList->count();
    ui->label_totalCases->setNum(docket);
    ui->label_totalCasesHeard->setNum(0);
    ui->label_ordersDate->setText("Jul 23 2013");
}

void MainWindow::on_toolButton_currentDocket_clicked()
{
    ui->listWidget_caseOrderList->clear();
    ui->listWidget_caseOrderList->addItem("22-1251");
    ui->listWidget_caseOrderList->addItem("22-1267");
    ui->listWidget_caseOrderList->addItem("22-1284");
    ui->listWidget_caseOrderList->addItem("22-1200");
    ui->toolButton_nextDocket->setEnabled(false);
    ui->toolButton_currentDocket->setEnabled(false);
    ui->toolButton_previousDocket->setEnabled(true);
    int docket;
    docket = ui->listWidget_caseOrderList->count();
    ui->label_totalCases->setNum(docket);
    ui->label_totalCasesHeard->setNum(0);
    ui->label_ordersDate->setText("Jul 23 2013");
}


// APPLICATION FUNCTIONS
void MainWindow::on_toolButton_Logout_clicked()
{
    QApplication::exit(0);
}

