#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QCompleter>
#include <QDirModel>
#include <QtGui>
#include <QtCore>
#include <QDebug>
#include <QtSql>

#include"userupdate.h"
#include"confirm.h"
#include"adddocket.h"
#include"newcase.h"
#include"consolidate.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
// BUILD FACCTS CONFIGURATION
void AddCourtLocations(QString cname, QString cdivision, QString cstreet, QString cmailing, QString locationid);
void AddCourtCourtrooms(QString clocation, QString cname, QString cjudge);
void AddCourtDepartments(QString dname, QString droom, QString dofficer, QString dreporter);
void AddCourtAgencies(QString aname, QString aori);
void LoadUserSet();
void LoadSecurity();

// BUILD COURT ORDER TABLES DYNAMICALLY
void AddRootChildren(QString entitychild, QString fnamechild, QString lnamechild, QString relationchild, QString dobchild, QString sexchild);
void AddRootOtherProtected(QString entityother, QString fname, QString lname, QString relation, QString dob, QString sex);
void AddRootWitness(QString entitywitness, QString fnamewitness, QString lnamewitness, QString designationwitness, QString partywitness, QString contactwitness);
void AddRootInterpreter(QString entityinterpreter, QString fnameinterpreter, QString lnameinterpreter, QString designationinterpreter, QString partyinterpreter, QString contactinterpreter);
void AddRootChildrenOrder(QString entity3, QString fullname);
void AddRootRelatedCase(QString casenumber, QString casetype, QString county, QString CPO, QString expiration, QString leadcase);
void AddRootCaseHistory(QString date, QString event, QString p1present, QString p1sworn, QString p1atty, QString p2present, QString p2sworn, QString p2atty, QString orders, QString mergecase);
void AddRootPropertyControl(QString pcItem, QString pcDescription);
void AddRootDebtPayment(QString dpItem, QString dpPaymentTo, QString dpPaymentFor, QString dpPaymentFrom, QString dpDate);
void AddRootDV110Children(QString ccEntity, QString ccFname, QString ccLname, QString ccDOB, QString ccLegal, QString ccPhysical);
void AddRootDV130OtherProtect(QString entity130, QString fullname130);
void AddRootDV130PropertyControl(QString pcItem, QString pcDescription);
void AddRootDV130Children(QString ccEntity, QString ccFname, QString ccLname, QString ccDOB, QString ccLegal, QString ccPhysical);
void AddRootDV130DebtPayment(QString dpItem, QString dpPaymentTo, QString dpPaymentFor, QString dpPaymentFrom, QString dpDate);
void AddRootDV130ChildSupport(QString csFirst, QString csLast, QString csPaidTo, QString csAmount);
void AddRootDV130Income(QString csRole, QString csGross, QString csNet, QString csCalWork, QString csImputIncome, QString csImputMonth);
void AddRootDV130Hardship(QString csHardship, QString csPetitioner, QString csRespondent, QString csOther, QString csEndDate);
void AddRootDV130FamilySupport(QString ssDesignation, QString ssFname, QString ssGross, QString ssDeductions, QString ssHardship, QString ssCalWorks, QString ssNet);
void AddRootEA110OthersProtected(QString eaEntity, QString eaName, QString eaRelation, QString eaHousehold, QString eaAge, QString eaSex);
void AddRootEA110LawEnforcement(QString eaAgency, QString eaAddress);
void AddRootEA130OthersProtected(QString eaEntity, QString eaName, QString eaRelation, QString eaHousehold, QString eaAge, QString eaSex);
void AddRootEA130LawEnforcement(QString eaAgency, QString eaAddress);
void AddRootCH110OthersProtected(QString chEntity, QString chName, QString chRelation, QString chHousehold, QString chAge, QString chSex);
void AddRootCH110LawEnforcement(QString chAgency, QString chAddress);
void AddRootCH130OthersProtected(QString chEntity, QString chName, QString chRelation, QString chHousehold, QString chAge, QString chSex);
void AddRootCH130LawEnforcement(QString chAgency, QString chAddress);
void AddRootCH130Payments(QString chItem, QString chAmount);
void AddRootFL344Property(QString pcItem, QString pcGivenTo);
void AddRootFL344DebtPayment(QString pcDebt, QString pcPayment,QString pcDebtPayBy, QString pcDebtPayTo);

// OPERATON FUNCTIONS
void SaveCaseRecord();
void LoadConfiguration();
void SetDefaultsPrevious();
void ResetRecordTables();
void ResetOrderTables();
void LoadCaseRecord();
void LoadCaseHeader();
void LoadCaseOrdersDV110();
void LoadCaseOrdersDV130();
void LoadCaseOrdersCH110();
void LoadCaseOrdersCH130();
void LoadCaseOrdersEA110();
void LoadCaseOrdersEA130();
void LoadCaseOrdersFL344();
void LoadCaseSummaryFL340();
void LoadCaseFindingFL341();
void UnsignCase();

//DOCKET FUNCTIONS
void LoadNoDocketList();


public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

//void AddNewCaseList(QString addCaseId);


public slots:


private slots:
    void on_toolButton_caseDrop_clicked();   
    void on_toolButton_CaseMerge_clicked();
    void on_toolButton_Logout_clicked();

// PANEL OPERATIONS
    void on_toolButton_copyp1Attorney_clicked();
    void on_toolButton_copyp2Attorney_clicked();
    void on_toolButton_visitWeekendAll_clicked();
    void on_toolButton_visitWeekendAlternate_clicked();

// DIALOG WINDOWS
    void on_toolButton_caseSave_clicked();
    void on_toolButton_caseRecordNew_clicked();
    void on_toolButton_caseReissueDocket_clicked();
    void on_toolButton_caseExport_clicked();
    void on_toolButton_saveOrders_clicked();
    void on_toolButton_caseReissueOrder_clicked();
    void on_toolButton_staffUpdate_clicked();
    void on_toolButton_CaseAddDocket_clicked();
    void on_toolButton_CaseSeperate_clicked();
    void on_toolButton_caseContinuance_clicked();
    void on_toolButton_caseStatus_clicked();
    void on_toolButton_addCaseMerge_clicked();
    void on_toolButton_generateOrders_clicked();
    void on_toolButton_caseRenew_clicked();
    void on_toolButton_AddParties_clicked();
    void on_toolButton_visitEvenWeekend_clicked();

//DV130 VISITATION SCHEDULER
    void on_toolButton_visitDV130AllWeekend_clicked();
    void on_toolButton_visitDV130OddWeekend_clicked();
    void on_toolButton_visitDV130EvenWeekend_clicked();

//LOAD CASE RECORD ON SELECTION
    void on_listWidget_listCaseRecord_itemSelectionChanged();

//COURT ORDERS OPERATIONS
    void on_listWidget_caseOrderList_itemSelectionChanged();
    void on_toolButton_previousDocket_clicked();
    void on_toolButton_nextDocket_clicked();
    void on_toolButton_currentDocket_clicked();
    void on_toolButton_unscheduleCase_clicked();
    void on_toolButton_CaseClear_clicked();
//    void on_toolButton_sealUpdate_2_clicked();

private:
    Ui::MainWindow *ui;
    QCompleter *WeekdayCompleter;
    QCompleter *WeekendCompleter;
};

#endif // MAINWINDOW_H


