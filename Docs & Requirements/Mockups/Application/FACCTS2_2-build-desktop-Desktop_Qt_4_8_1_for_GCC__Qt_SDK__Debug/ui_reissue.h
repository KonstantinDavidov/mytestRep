/********************************************************************************
** Form generated from reading UI file 'reissue.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_REISSUE_H
#define UI_REISSUE_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QCheckBox>
#include <QtGui/QComboBox>
#include <QtGui/QDateEdit>
#include <QtGui/QDialog>
#include <QtGui/QFrame>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QRadioButton>
#include <QtGui/QTextEdit>
#include <QtGui/QTimeEdit>
#include <QtGui/QToolButton>

QT_BEGIN_NAMESPACE

class Ui_Reissue
{
public:
    QToolButton *toolButton_docketAddCase;
    QLabel *label_docketAddCaseTitle;
    QFrame *line_lowerAddCaseDocket;
    QLabel *label_6;
    QToolButton *toolButton_docketAddCaseCancel;
    QFrame *line_mainAddCaseDocket;
    QFrame *line;
    QFrame *frame;
    QRadioButton *radioButton_noService;
    QLabel *label_7;
    QRadioButton *radioButton_p1Required;
    QRadioButton *radioButton_p2Required;
    QLineEdit *lineEdit_p1Days;
    QLineEdit *lineEdit_p2Days;
    QLabel *label_8;
    QLabel *label_9;
    QFrame *line_mainAddCaseDocket_2;
    QFrame *line_2;
    QLabel *label_11;
    QFrame *frame_2;
    QRadioButton *radioButton_troNo;
    QRadioButton *radioButton_troGranted;
    QRadioButton *radioButton_troDenied;
    QTextEdit *textEdit_deniedReason;
    QCheckBox *checkBox_5;
    QCheckBox *checkBox_3;
    QCheckBox *checkBox_2;
    QCheckBox *checkBox_p2NotServed;
    QLineEdit *lineEdit;
    QLabel *label;
    QLabel *label_10;
    QDateEdit *dateEdit_hearingDate;
    QLabel *label_2;
    QTimeEdit *timeEdit_hearingTime;
    QLabel *label_4;
    QComboBox *comboBox_Courtroom;
    QLabel *label_5;
    QComboBox *comboBox_Department;
    QLineEdit *lineEdit_caseNumber;

    void setupUi(QDialog *Reissue)
    {
        if (Reissue->objectName().isEmpty())
            Reissue->setObjectName(QString::fromUtf8("Reissue"));
        Reissue->resize(664, 384);
        QFont font;
        font.setPointSize(11);
        Reissue->setFont(font);
        toolButton_docketAddCase = new QToolButton(Reissue);
        toolButton_docketAddCase->setObjectName(QString::fromUtf8("toolButton_docketAddCase"));
        toolButton_docketAddCase->setGeometry(QRect(475, 340, 85, 23));
        label_docketAddCaseTitle = new QLabel(Reissue);
        label_docketAddCaseTitle->setObjectName(QString::fromUtf8("label_docketAddCaseTitle"));
        label_docketAddCaseTitle->setGeometry(QRect(30, 40, 226, 23));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_docketAddCaseTitle->setFont(font1);
        line_lowerAddCaseDocket = new QFrame(Reissue);
        line_lowerAddCaseDocket->setObjectName(QString::fromUtf8("line_lowerAddCaseDocket"));
        line_lowerAddCaseDocket->setGeometry(QRect(310, 325, 346, 16));
        line_lowerAddCaseDocket->setFrameShape(QFrame::HLine);
        line_lowerAddCaseDocket->setFrameShadow(QFrame::Sunken);
        label_6 = new QLabel(Reissue);
        label_6->setObjectName(QString::fromUtf8("label_6"));
        label_6->setGeometry(QRect(295, 65, 176, 23));
        label_6->setFont(font);
        toolButton_docketAddCaseCancel = new QToolButton(Reissue);
        toolButton_docketAddCaseCancel->setObjectName(QString::fromUtf8("toolButton_docketAddCaseCancel"));
        toolButton_docketAddCaseCancel->setGeometry(QRect(565, 340, 85, 23));
        line_mainAddCaseDocket = new QFrame(Reissue);
        line_mainAddCaseDocket->setObjectName(QString::fromUtf8("line_mainAddCaseDocket"));
        line_mainAddCaseDocket->setGeometry(QRect(30, 55, 601, 16));
        line_mainAddCaseDocket->setFrameShape(QFrame::HLine);
        line_mainAddCaseDocket->setFrameShadow(QFrame::Sunken);
        line = new QFrame(Reissue);
        line->setObjectName(QString::fromUtf8("line"));
        line->setGeometry(QRect(270, 70, 21, 156));
        line->setFrameShape(QFrame::VLine);
        line->setFrameShadow(QFrame::Sunken);
        frame = new QFrame(Reissue);
        frame->setObjectName(QString::fromUtf8("frame"));
        frame->setGeometry(QRect(50, 240, 401, 96));
        frame->setFrameShape(QFrame::NoFrame);
        frame->setFrameShadow(QFrame::Raised);
        radioButton_noService = new QRadioButton(frame);
        radioButton_noService->setObjectName(QString::fromUtf8("radioButton_noService"));
        radioButton_noService->setGeometry(QRect(5, 20, 146, 22));
        label_7 = new QLabel(frame);
        label_7->setObjectName(QString::fromUtf8("label_7"));
        label_7->setGeometry(QRect(10, 0, 161, 23));
        label_7->setFont(font);
        radioButton_p1Required = new QRadioButton(frame);
        radioButton_p1Required->setObjectName(QString::fromUtf8("radioButton_p1Required"));
        radioButton_p1Required->setGeometry(QRect(5, 45, 166, 22));
        radioButton_p2Required = new QRadioButton(frame);
        radioButton_p2Required->setObjectName(QString::fromUtf8("radioButton_p2Required"));
        radioButton_p2Required->setGeometry(QRect(5, 70, 171, 22));
        lineEdit_p1Days = new QLineEdit(frame);
        lineEdit_p1Days->setObjectName(QString::fromUtf8("lineEdit_p1Days"));
        lineEdit_p1Days->setGeometry(QRect(180, 45, 26, 21));
        lineEdit_p2Days = new QLineEdit(frame);
        lineEdit_p2Days->setObjectName(QString::fromUtf8("lineEdit_p2Days"));
        lineEdit_p2Days->setGeometry(QRect(180, 70, 26, 21));
        label_8 = new QLabel(frame);
        label_8->setObjectName(QString::fromUtf8("label_8"));
        label_8->setGeometry(QRect(210, 45, 141, 21));
        label_8->setFont(font);
        label_9 = new QLabel(frame);
        label_9->setObjectName(QString::fromUtf8("label_9"));
        label_9->setGeometry(QRect(210, 70, 141, 21));
        label_9->setFont(font);
        line_mainAddCaseDocket_2 = new QFrame(Reissue);
        line_mainAddCaseDocket_2->setObjectName(QString::fromUtf8("line_mainAddCaseDocket_2"));
        line_mainAddCaseDocket_2->setGeometry(QRect(50, 230, 581, 16));
        line_mainAddCaseDocket_2->setFrameShape(QFrame::HLine);
        line_mainAddCaseDocket_2->setFrameShadow(QFrame::Sunken);
        line_2 = new QFrame(Reissue);
        line_2->setObjectName(QString::fromUtf8("line_2"));
        line_2->setGeometry(QRect(455, 70, 31, 156));
        line_2->setFrameShape(QFrame::VLine);
        line_2->setFrameShadow(QFrame::Sunken);
        label_11 = new QLabel(Reissue);
        label_11->setObjectName(QString::fromUtf8("label_11"));
        label_11->setGeometry(QRect(485, 65, 176, 23));
        label_11->setFont(font);
        frame_2 = new QFrame(Reissue);
        frame_2->setObjectName(QString::fromUtf8("frame_2"));
        frame_2->setGeometry(QRect(475, 90, 166, 141));
        frame_2->setFrameShape(QFrame::NoFrame);
        frame_2->setFrameShadow(QFrame::Raised);
        radioButton_troNo = new QRadioButton(frame_2);
        radioButton_troNo->setObjectName(QString::fromUtf8("radioButton_troNo"));
        radioButton_troNo->setGeometry(QRect(5, 0, 136, 20));
        radioButton_troGranted = new QRadioButton(frame_2);
        radioButton_troGranted->setObjectName(QString::fromUtf8("radioButton_troGranted"));
        radioButton_troGranted->setGeometry(QRect(5, 25, 102, 20));
        radioButton_troDenied = new QRadioButton(frame_2);
        radioButton_troDenied->setObjectName(QString::fromUtf8("radioButton_troDenied"));
        radioButton_troDenied->setGeometry(QRect(5, 50, 102, 20));
        textEdit_deniedReason = new QTextEdit(frame_2);
        textEdit_deniedReason->setObjectName(QString::fromUtf8("textEdit_deniedReason"));
        textEdit_deniedReason->setGeometry(QRect(5, 80, 156, 51));
        checkBox_5 = new QCheckBox(Reissue);
        checkBox_5->setObjectName(QString::fromUtf8("checkBox_5"));
        checkBox_5->setGeometry(QRect(285, 163, 156, 18));
        checkBox_3 = new QCheckBox(Reissue);
        checkBox_3->setObjectName(QString::fromUtf8("checkBox_3"));
        checkBox_3->setGeometry(QRect(285, 140, 176, 18));
        checkBox_2 = new QCheckBox(Reissue);
        checkBox_2->setObjectName(QString::fromUtf8("checkBox_2"));
        checkBox_2->setGeometry(QRect(285, 117, 90, 18));
        checkBox_p2NotServed = new QCheckBox(Reissue);
        checkBox_p2NotServed->setObjectName(QString::fromUtf8("checkBox_p2NotServed"));
        checkBox_p2NotServed->setGeometry(QRect(285, 94, 166, 18));
        lineEdit = new QLineEdit(Reissue);
        lineEdit->setObjectName(QString::fromUtf8("lineEdit"));
        lineEdit->setEnabled(false);
        lineEdit->setGeometry(QRect(287, 191, 176, 21));
        label = new QLabel(Reissue);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(51, 81, 72, 16));
        label->setFont(font);
        label_10 = new QLabel(Reissue);
        label_10->setObjectName(QString::fromUtf8("label_10"));
        label_10->setGeometry(QRect(51, 111, 88, 16));
        label_10->setFont(font);
        dateEdit_hearingDate = new QDateEdit(Reissue);
        dateEdit_hearingDate->setObjectName(QString::fromUtf8("dateEdit_hearingDate"));
        dateEdit_hearingDate->setGeometry(QRect(165, 111, 88, 24));
        dateEdit_hearingDate->setDateTime(QDateTime(QDate(2013, 6, 14), QTime(0, 0, 0)));
        label_2 = new QLabel(Reissue);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(51, 141, 27, 16));
        label_2->setFont(font);
        timeEdit_hearingTime = new QTimeEdit(Reissue);
        timeEdit_hearingTime->setObjectName(QString::fromUtf8("timeEdit_hearingTime"));
        timeEdit_hearingTime->setGeometry(QRect(165, 141, 86, 24));
        label_4 = new QLabel(Reissue);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(51, 172, 59, 16));
        label_4->setFont(font);
        comboBox_Courtroom = new QComboBox(Reissue);
        comboBox_Courtroom->setObjectName(QString::fromUtf8("comboBox_Courtroom"));
        comboBox_Courtroom->setGeometry(QRect(147, 170, 124, 26));
        label_5 = new QLabel(Reissue);
        label_5->setObjectName(QString::fromUtf8("label_5"));
        label_5->setGeometry(QRect(51, 202, 64, 16));
        label_5->setFont(font);
        comboBox_Department = new QComboBox(Reissue);
        comboBox_Department->setObjectName(QString::fromUtf8("comboBox_Department"));
        comboBox_Department->setGeometry(QRect(161, 200, 104, 26));
        lineEdit_caseNumber = new QLineEdit(Reissue);
        lineEdit_caseNumber->setObjectName(QString::fromUtf8("lineEdit_caseNumber"));
        lineEdit_caseNumber->setGeometry(QRect(160, 80, 113, 21));

        retranslateUi(Reissue);
        QObject::connect(checkBox_5, SIGNAL(toggled(bool)), lineEdit, SLOT(setEnabled(bool)));
        QObject::connect(toolButton_docketAddCaseCancel, SIGNAL(clicked()), Reissue, SLOT(close()));
        QObject::connect(toolButton_docketAddCase, SIGNAL(clicked()), Reissue, SLOT(accept()));
        QObject::connect(radioButton_troDenied, SIGNAL(toggled(bool)), textEdit_deniedReason, SLOT(setEnabled(bool)));

        QMetaObject::connectSlotsByName(Reissue);
    } // setupUi

    void retranslateUi(QDialog *Reissue)
    {
        Reissue->setWindowTitle(QApplication::translate("Reissue", "Reissuance", 0, QApplication::UnicodeUTF8));
        toolButton_docketAddCase->setText(QApplication::translate("Reissue", "REISSUE", 0, QApplication::UnicodeUTF8));
        label_docketAddCaseTitle->setText(QApplication::translate("Reissue", "CONFIRMATION:  REISSUE CASE", 0, QApplication::UnicodeUTF8));
        label_6->setText(QApplication::translate("Reissue", "Reasons", 0, QApplication::UnicodeUTF8));
        toolButton_docketAddCaseCancel->setText(QApplication::translate("Reissue", "CANCEL", 0, QApplication::UnicodeUTF8));
        radioButton_noService->setText(QApplication::translate("Reissue", "No Service Required", 0, QApplication::UnicodeUTF8));
        label_7->setText(QApplication::translate("Reissue", "Service", 0, QApplication::UnicodeUTF8));
        radioButton_p1Required->setText(QApplication::translate("Reissue", "Service Required to Party 1 ", 0, QApplication::UnicodeUTF8));
        radioButton_p2Required->setText(QApplication::translate("Reissue", "Service Required to Party 2", 0, QApplication::UnicodeUTF8));
        label_8->setText(QApplication::translate("Reissue", "days before the hearing.", 0, QApplication::UnicodeUTF8));
        label_9->setText(QApplication::translate("Reissue", "days before the hearing.", 0, QApplication::UnicodeUTF8));
        label_11->setText(QApplication::translate("Reissue", "Reissue TRO", 0, QApplication::UnicodeUTF8));
        radioButton_troNo->setText(QApplication::translate("Reissue", "No TRO was Issued", 0, QApplication::UnicodeUTF8));
        radioButton_troGranted->setText(QApplication::translate("Reissue", "TRO Granted", 0, QApplication::UnicodeUTF8));
        radioButton_troDenied->setText(QApplication::translate("Reissue", "TRO Denied", 0, QApplication::UnicodeUTF8));
        checkBox_5->setText(QApplication::translate("Reissue", "Other Reason", 0, QApplication::UnicodeUTF8));
        checkBox_3->setText(QApplication::translate("Reissue", "P2 Request Attorney", 0, QApplication::UnicodeUTF8));
        checkBox_2->setText(QApplication::translate("Reissue", "FCS Referral", 0, QApplication::UnicodeUTF8));
        checkBox_p2NotServed->setText(QApplication::translate("Reissue", "No POS to Party 2", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("Reissue", "Case Number", 0, QApplication::UnicodeUTF8));
        label_10->setText(QApplication::translate("Reissue", "New Court Date:", 0, QApplication::UnicodeUTF8));
        label_2->setText(QApplication::translate("Reissue", "Time", 0, QApplication::UnicodeUTF8));
        label_4->setText(QApplication::translate("Reissue", "Courtroom", 0, QApplication::UnicodeUTF8));
        comboBox_Courtroom->clear();
        comboBox_Courtroom->insertItems(0, QStringList()
         << QApplication::translate("Reissue", "Courtroom A", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Reissue", "Courtroom B", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Reissue", "Courtroom C", 0, QApplication::UnicodeUTF8)
        );
        label_5->setText(QApplication::translate("Reissue", "Department", 0, QApplication::UnicodeUTF8));
        comboBox_Department->clear();
        comboBox_Department->insertItems(0, QStringList()
         << QApplication::translate("Reissue", "G1", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Reissue", "G2", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Reissue", "G3", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Reissue", "New Item", 0, QApplication::UnicodeUTF8)
        );
    } // retranslateUi

};

namespace Ui {
    class Reissue: public Ui_Reissue {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_REISSUE_H
