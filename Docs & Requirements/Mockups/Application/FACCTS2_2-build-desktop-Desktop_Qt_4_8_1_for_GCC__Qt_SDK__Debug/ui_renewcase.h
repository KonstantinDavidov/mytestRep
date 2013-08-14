/********************************************************************************
** Form generated from reading UI file 'renewcase.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_RENEWCASE_H
#define UI_RENEWCASE_H

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
#include <QtGui/QTimeEdit>
#include <QtGui/QToolButton>

QT_BEGIN_NAMESPACE

class Ui_renewCase
{
public:
    QLabel *label_RenewCase;
    QFrame *line;
    QFrame *line_2;
    QToolButton *toolButton_cancel;
    QToolButton *toolButton_renew;
    QTimeEdit *timeEdit_hearingTime;
    QDateEdit *dateEdit_hearingDate;
    QLineEdit *lineEdit_caseNumber;
    QComboBox *comboBox_Department;
    QComboBox *comboBox_Courtroom;
    QFrame *line_3;
    QCheckBox *checkBox_renewGranted;
    QCheckBox *checkBox_renewDenied;
    QRadioButton *radioButton;
    QRadioButton *radioButton_2;
    QDateEdit *dateEdit_expireDate;
    QTimeEdit *timeEdit_expireTime;
    QCheckBox *checkBox;
    QRadioButton *radioButton_3;
    QLabel *label_caseNumber;
    QLabel *label_caseNumber_2;
    QLabel *label_caseNumber_3;
    QLabel *label_caseNumber_4;
    QLabel *label_caseNumber_5;

    void setupUi(QDialog *renewCase)
    {
        if (renewCase->objectName().isEmpty())
            renewCase->setObjectName(QString::fromUtf8("renewCase"));
        renewCase->resize(552, 315);
        QFont font;
        font.setPointSize(11);
        renewCase->setFont(font);
        label_RenewCase = new QLabel(renewCase);
        label_RenewCase->setObjectName(QString::fromUtf8("label_RenewCase"));
        label_RenewCase->setGeometry(QRect(40, 40, 211, 16));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_RenewCase->setFont(font1);
        line = new QFrame(renewCase);
        line->setObjectName(QString::fromUtf8("line"));
        line->setGeometry(QRect(40, 50, 476, 16));
        line->setFrameShape(QFrame::HLine);
        line->setFrameShadow(QFrame::Sunken);
        line_2 = new QFrame(renewCase);
        line_2->setObjectName(QString::fromUtf8("line_2"));
        line_2->setGeometry(QRect(220, 230, 296, 16));
        line_2->setFrameShape(QFrame::HLine);
        line_2->setFrameShadow(QFrame::Sunken);
        toolButton_cancel = new QToolButton(renewCase);
        toolButton_cancel->setObjectName(QString::fromUtf8("toolButton_cancel"));
        toolButton_cancel->setGeometry(QRect(445, 245, 71, 23));
        toolButton_renew = new QToolButton(renewCase);
        toolButton_renew->setObjectName(QString::fromUtf8("toolButton_renew"));
        toolButton_renew->setGeometry(QRect(370, 245, 71, 23));
        timeEdit_hearingTime = new QTimeEdit(renewCase);
        timeEdit_hearingTime->setObjectName(QString::fromUtf8("timeEdit_hearingTime"));
        timeEdit_hearingTime->setGeometry(QRect(185, 120, 86, 24));
        dateEdit_hearingDate = new QDateEdit(renewCase);
        dateEdit_hearingDate->setObjectName(QString::fromUtf8("dateEdit_hearingDate"));
        dateEdit_hearingDate->setGeometry(QRect(185, 95, 86, 24));
        lineEdit_caseNumber = new QLineEdit(renewCase);
        lineEdit_caseNumber->setObjectName(QString::fromUtf8("lineEdit_caseNumber"));
        lineEdit_caseNumber->setGeometry(QRect(165, 70, 106, 21));
        comboBox_Department = new QComboBox(renewCase);
        comboBox_Department->setObjectName(QString::fromUtf8("comboBox_Department"));
        comboBox_Department->setGeometry(QRect(160, 145, 111, 26));
        comboBox_Courtroom = new QComboBox(renewCase);
        comboBox_Courtroom->setObjectName(QString::fromUtf8("comboBox_Courtroom"));
        comboBox_Courtroom->setGeometry(QRect(160, 170, 111, 26));
        line_3 = new QFrame(renewCase);
        line_3->setObjectName(QString::fromUtf8("line_3"));
        line_3->setGeometry(QRect(285, 65, 16, 166));
        line_3->setFrameShape(QFrame::VLine);
        line_3->setFrameShadow(QFrame::Sunken);
        checkBox_renewGranted = new QCheckBox(renewCase);
        checkBox_renewGranted->setObjectName(QString::fromUtf8("checkBox_renewGranted"));
        checkBox_renewGranted->setGeometry(QRect(300, 65, 141, 20));
        QFont font2;
        font2.setBold(true);
        font2.setWeight(75);
        checkBox_renewGranted->setFont(font2);
        checkBox_renewDenied = new QCheckBox(renewCase);
        checkBox_renewDenied->setObjectName(QString::fromUtf8("checkBox_renewDenied"));
        checkBox_renewDenied->setGeometry(QRect(305, 210, 141, 20));
        checkBox_renewDenied->setFont(font2);
        radioButton = new QRadioButton(renewCase);
        radioButton->setObjectName(QString::fromUtf8("radioButton"));
        radioButton->setGeometry(QRect(320, 85, 76, 20));
        radioButton_2 = new QRadioButton(renewCase);
        radioButton_2->setObjectName(QString::fromUtf8("radioButton_2"));
        radioButton_2->setGeometry(QRect(420, 85, 91, 20));
        dateEdit_expireDate = new QDateEdit(renewCase);
        dateEdit_expireDate->setObjectName(QString::fromUtf8("dateEdit_expireDate"));
        dateEdit_expireDate->setEnabled(false);
        dateEdit_expireDate->setGeometry(QRect(340, 135, 86, 24));
        timeEdit_expireTime = new QTimeEdit(renewCase);
        timeEdit_expireTime->setObjectName(QString::fromUtf8("timeEdit_expireTime"));
        timeEdit_expireTime->setEnabled(false);
        timeEdit_expireTime->setGeometry(QRect(430, 135, 86, 24));
        checkBox = new QCheckBox(renewCase);
        checkBox->setObjectName(QString::fromUtf8("checkBox"));
        checkBox->setEnabled(false);
        checkBox->setGeometry(QRect(430, 165, 87, 20));
        radioButton_3 = new QRadioButton(renewCase);
        radioButton_3->setObjectName(QString::fromUtf8("radioButton_3"));
        radioButton_3->setGeometry(QRect(320, 110, 186, 20));
        label_caseNumber = new QLabel(renewCase);
        label_caseNumber->setObjectName(QString::fromUtf8("label_caseNumber"));
        label_caseNumber->setGeometry(QRect(55, 70, 81, 23));
        label_caseNumber->setFont(font);
        label_caseNumber_2 = new QLabel(renewCase);
        label_caseNumber_2->setObjectName(QString::fromUtf8("label_caseNumber_2"));
        label_caseNumber_2->setGeometry(QRect(55, 95, 101, 23));
        label_caseNumber_2->setFont(font);
        label_caseNumber_3 = new QLabel(renewCase);
        label_caseNumber_3->setObjectName(QString::fromUtf8("label_caseNumber_3"));
        label_caseNumber_3->setGeometry(QRect(55, 120, 101, 23));
        label_caseNumber_3->setFont(font);
        label_caseNumber_4 = new QLabel(renewCase);
        label_caseNumber_4->setObjectName(QString::fromUtf8("label_caseNumber_4"));
        label_caseNumber_4->setGeometry(QRect(55, 145, 101, 23));
        label_caseNumber_4->setFont(font);
        label_caseNumber_5 = new QLabel(renewCase);
        label_caseNumber_5->setObjectName(QString::fromUtf8("label_caseNumber_5"));
        label_caseNumber_5->setGeometry(QRect(55, 170, 101, 23));
        label_caseNumber_5->setFont(font);

        retranslateUi(renewCase);
        QObject::connect(radioButton_3, SIGNAL(toggled(bool)), dateEdit_expireDate, SLOT(setEnabled(bool)));
        QObject::connect(radioButton_3, SIGNAL(toggled(bool)), timeEdit_expireTime, SLOT(setEnabled(bool)));
        QObject::connect(radioButton_3, SIGNAL(toggled(bool)), checkBox, SLOT(setEnabled(bool)));
        QObject::connect(toolButton_cancel, SIGNAL(clicked()), renewCase, SLOT(close()));
        QObject::connect(toolButton_renew, SIGNAL(clicked()), renewCase, SLOT(accept()));

        QMetaObject::connectSlotsByName(renewCase);
    } // setupUi

    void retranslateUi(QDialog *renewCase)
    {
        renewCase->setWindowTitle(QApplication::translate("renewCase", "Dialog", 0, QApplication::UnicodeUTF8));
        label_RenewCase->setText(QApplication::translate("renewCase", "CONFIRMATION: RENEW CASE", 0, QApplication::UnicodeUTF8));
        toolButton_cancel->setText(QApplication::translate("renewCase", "CANCEL", 0, QApplication::UnicodeUTF8));
        toolButton_renew->setText(QApplication::translate("renewCase", "UPDATE", 0, QApplication::UnicodeUTF8));
        comboBox_Department->clear();
        comboBox_Department->insertItems(0, QStringList()
         << QApplication::translate("renewCase", "G1", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("renewCase", "G2", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("renewCase", "G3", 0, QApplication::UnicodeUTF8)
        );
        comboBox_Courtroom->clear();
        comboBox_Courtroom->insertItems(0, QStringList()
         << QApplication::translate("renewCase", "Courtroom A", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("renewCase", "Courtroom B", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("renewCase", "Courtroom C", 0, QApplication::UnicodeUTF8)
        );
        checkBox_renewGranted->setText(QApplication::translate("renewCase", "Renew Granted", 0, QApplication::UnicodeUTF8));
        checkBox_renewDenied->setText(QApplication::translate("renewCase", "Renew Denied", 0, QApplication::UnicodeUTF8));
        radioButton->setText(QApplication::translate("renewCase", "5 Years", 0, QApplication::UnicodeUTF8));
        radioButton_2->setText(QApplication::translate("renewCase", "Permanent", 0, QApplication::UnicodeUTF8));
        checkBox->setText(QApplication::translate("renewCase", "Midnight", 0, QApplication::UnicodeUTF8));
        radioButton_3->setText(QApplication::translate("renewCase", "Set Expiration Date", 0, QApplication::UnicodeUTF8));
        label_caseNumber->setText(QApplication::translate("renewCase", "Case Number", 0, QApplication::UnicodeUTF8));
        label_caseNumber_2->setText(QApplication::translate("renewCase", "New Hearing Date", 0, QApplication::UnicodeUTF8));
        label_caseNumber_3->setText(QApplication::translate("renewCase", "New Hearing Time", 0, QApplication::UnicodeUTF8));
        label_caseNumber_4->setText(QApplication::translate("renewCase", "Department", 0, QApplication::UnicodeUTF8));
        label_caseNumber_5->setText(QApplication::translate("renewCase", "Courtroom", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class renewCase: public Ui_renewCase {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_RENEWCASE_H
