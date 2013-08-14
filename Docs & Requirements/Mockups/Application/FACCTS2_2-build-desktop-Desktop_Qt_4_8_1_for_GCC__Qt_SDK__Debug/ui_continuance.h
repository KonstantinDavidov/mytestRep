/********************************************************************************
** Form generated from reading UI file 'continuance.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CONTINUANCE_H
#define UI_CONTINUANCE_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QComboBox>
#include <QtGui/QDateEdit>
#include <QtGui/QDialog>
#include <QtGui/QFrame>
#include <QtGui/QHBoxLayout>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QTimeEdit>
#include <QtGui/QToolButton>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Continuance
{
public:
    QToolButton *toolButton_Cancel;
    QToolButton *toolButton_Update;
    QLabel *label_Title;
    QFrame *line_mainConsolidate;
    QWidget *layoutWidget;
    QHBoxLayout *horizontalLayout;
    QLabel *label_4;
    QTimeEdit *timeEdit_continueTime;
    QWidget *layoutWidget1;
    QHBoxLayout *horizontalLayout_2;
    QLabel *label_3;
    QDateEdit *dateEdit_continueDate;
    QWidget *layoutWidget2;
    QHBoxLayout *horizontalLayout_3;
    QLabel *label_2;
    QLineEdit *lineEdit_caseNumber;
    QLabel *label;
    QFrame *line_mainConsolidate_2;
    QComboBox *comboBox_Department;
    QComboBox *comboBox_Courtroom;
    QWidget *layoutWidget3;
    QHBoxLayout *horizontalLayout_4;
    QLabel *label_requestParty;
    QComboBox *comboBox_requestParty;
    QWidget *layoutWidget4;
    QHBoxLayout *horizontalLayout_5;
    QLabel *label_reason;
    QComboBox *comboBox_reason;
    QWidget *layoutWidget5;
    QHBoxLayout *horizontalLayout_6;
    QLabel *label_reason_2;
    QLineEdit *lineEdit_otherDetail;
    QLabel *label_5;
    QLabel *label_6;

    void setupUi(QDialog *Continuance)
    {
        if (Continuance->objectName().isEmpty())
            Continuance->setObjectName(QString::fromUtf8("Continuance"));
        Continuance->resize(556, 319);
        QFont font;
        font.setPointSize(11);
        Continuance->setFont(font);
        toolButton_Cancel = new QToolButton(Continuance);
        toolButton_Cancel->setObjectName(QString::fromUtf8("toolButton_Cancel"));
        toolButton_Cancel->setGeometry(QRect(475, 280, 66, 23));
        toolButton_Update = new QToolButton(Continuance);
        toolButton_Update->setObjectName(QString::fromUtf8("toolButton_Update"));
        toolButton_Update->setGeometry(QRect(400, 280, 66, 23));
        label_Title = new QLabel(Continuance);
        label_Title->setObjectName(QString::fromUtf8("label_Title"));
        label_Title->setGeometry(QRect(40, 50, 236, 16));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_Title->setFont(font1);
        line_mainConsolidate = new QFrame(Continuance);
        line_mainConsolidate->setObjectName(QString::fromUtf8("line_mainConsolidate"));
        line_mainConsolidate->setGeometry(QRect(40, 60, 501, 16));
        line_mainConsolidate->setFrameShape(QFrame::HLine);
        line_mainConsolidate->setFrameShadow(QFrame::Sunken);
        layoutWidget = new QWidget(Continuance);
        layoutWidget->setObjectName(QString::fromUtf8("layoutWidget"));
        layoutWidget->setGeometry(QRect(50, 175, 196, 27));
        horizontalLayout = new QHBoxLayout(layoutWidget);
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        horizontalLayout->setContentsMargins(0, 0, 0, 0);
        label_4 = new QLabel(layoutWidget);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setFont(font);

        horizontalLayout->addWidget(label_4);

        timeEdit_continueTime = new QTimeEdit(layoutWidget);
        timeEdit_continueTime->setObjectName(QString::fromUtf8("timeEdit_continueTime"));

        horizontalLayout->addWidget(timeEdit_continueTime);

        layoutWidget1 = new QWidget(Continuance);
        layoutWidget1->setObjectName(QString::fromUtf8("layoutWidget1"));
        layoutWidget1->setGeometry(QRect(50, 145, 196, 27));
        horizontalLayout_2 = new QHBoxLayout(layoutWidget1);
        horizontalLayout_2->setObjectName(QString::fromUtf8("horizontalLayout_2"));
        horizontalLayout_2->setContentsMargins(0, 0, 0, 0);
        label_3 = new QLabel(layoutWidget1);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setFont(font);

        horizontalLayout_2->addWidget(label_3);

        dateEdit_continueDate = new QDateEdit(layoutWidget1);
        dateEdit_continueDate->setObjectName(QString::fromUtf8("dateEdit_continueDate"));

        horizontalLayout_2->addWidget(dateEdit_continueDate);

        layoutWidget2 = new QWidget(Continuance);
        layoutWidget2->setObjectName(QString::fromUtf8("layoutWidget2"));
        layoutWidget2->setGeometry(QRect(50, 120, 196, 24));
        horizontalLayout_3 = new QHBoxLayout(layoutWidget2);
        horizontalLayout_3->setObjectName(QString::fromUtf8("horizontalLayout_3"));
        horizontalLayout_3->setContentsMargins(0, 0, 0, 0);
        label_2 = new QLabel(layoutWidget2);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setFont(font);

        horizontalLayout_3->addWidget(label_2);

        lineEdit_caseNumber = new QLineEdit(layoutWidget2);
        lineEdit_caseNumber->setObjectName(QString::fromUtf8("lineEdit_caseNumber"));

        horizontalLayout_3->addWidget(lineEdit_caseNumber);

        label = new QLabel(Continuance);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(50, 70, 476, 41));
        label->setFont(font);
        label->setWordWrap(true);
        line_mainConsolidate_2 = new QFrame(Continuance);
        line_mainConsolidate_2->setObjectName(QString::fromUtf8("line_mainConsolidate_2"));
        line_mainConsolidate_2->setGeometry(QRect(210, 265, 331, 16));
        line_mainConsolidate_2->setFrameShape(QFrame::HLine);
        line_mainConsolidate_2->setFrameShadow(QFrame::Sunken);
        comboBox_Department = new QComboBox(Continuance);
        comboBox_Department->setObjectName(QString::fromUtf8("comboBox_Department"));
        comboBox_Department->setGeometry(QRect(140, 205, 111, 26));
        comboBox_Courtroom = new QComboBox(Continuance);
        comboBox_Courtroom->setObjectName(QString::fromUtf8("comboBox_Courtroom"));
        comboBox_Courtroom->setGeometry(QRect(140, 230, 111, 26));
        layoutWidget3 = new QWidget(Continuance);
        layoutWidget3->setObjectName(QString::fromUtf8("layoutWidget3"));
        layoutWidget3->setGeometry(QRect(270, 120, 266, 26));
        horizontalLayout_4 = new QHBoxLayout(layoutWidget3);
        horizontalLayout_4->setObjectName(QString::fromUtf8("horizontalLayout_4"));
        horizontalLayout_4->setContentsMargins(0, 0, 0, 0);
        label_requestParty = new QLabel(layoutWidget3);
        label_requestParty->setObjectName(QString::fromUtf8("label_requestParty"));
        label_requestParty->setFont(font);

        horizontalLayout_4->addWidget(label_requestParty);

        comboBox_requestParty = new QComboBox(layoutWidget3);
        comboBox_requestParty->setObjectName(QString::fromUtf8("comboBox_requestParty"));

        horizontalLayout_4->addWidget(comboBox_requestParty);

        layoutWidget4 = new QWidget(Continuance);
        layoutWidget4->setObjectName(QString::fromUtf8("layoutWidget4"));
        layoutWidget4->setGeometry(QRect(270, 145, 266, 26));
        horizontalLayout_5 = new QHBoxLayout(layoutWidget4);
        horizontalLayout_5->setObjectName(QString::fromUtf8("horizontalLayout_5"));
        horizontalLayout_5->setContentsMargins(0, 0, 0, 0);
        label_reason = new QLabel(layoutWidget4);
        label_reason->setObjectName(QString::fromUtf8("label_reason"));
        label_reason->setFont(font);

        horizontalLayout_5->addWidget(label_reason);

        comboBox_reason = new QComboBox(layoutWidget4);
        comboBox_reason->setObjectName(QString::fromUtf8("comboBox_reason"));

        horizontalLayout_5->addWidget(comboBox_reason);

        layoutWidget5 = new QWidget(Continuance);
        layoutWidget5->setObjectName(QString::fromUtf8("layoutWidget5"));
        layoutWidget5->setGeometry(QRect(270, 175, 266, 24));
        horizontalLayout_6 = new QHBoxLayout(layoutWidget5);
        horizontalLayout_6->setObjectName(QString::fromUtf8("horizontalLayout_6"));
        horizontalLayout_6->setContentsMargins(0, 0, 0, 0);
        label_reason_2 = new QLabel(layoutWidget5);
        label_reason_2->setObjectName(QString::fromUtf8("label_reason_2"));
        label_reason_2->setFont(font);

        horizontalLayout_6->addWidget(label_reason_2);

        lineEdit_otherDetail = new QLineEdit(layoutWidget5);
        lineEdit_otherDetail->setObjectName(QString::fromUtf8("lineEdit_otherDetail"));

        horizontalLayout_6->addWidget(lineEdit_otherDetail);

        label_5 = new QLabel(Continuance);
        label_5->setObjectName(QString::fromUtf8("label_5"));
        label_5->setGeometry(QRect(50, 205, 81, 25));
        label_5->setFont(font);
        label_6 = new QLabel(Continuance);
        label_6->setObjectName(QString::fromUtf8("label_6"));
        label_6->setGeometry(QRect(50, 230, 81, 25));
        label_6->setFont(font);

        retranslateUi(Continuance);
        QObject::connect(toolButton_Cancel, SIGNAL(clicked()), Continuance, SLOT(close()));
        QObject::connect(toolButton_Update, SIGNAL(clicked()), Continuance, SLOT(accept()));

        QMetaObject::connectSlotsByName(Continuance);
    } // setupUi

    void retranslateUi(QDialog *Continuance)
    {
        Continuance->setWindowTitle(QApplication::translate("Continuance", "Case Continuance", 0, QApplication::UnicodeUTF8));
        toolButton_Cancel->setText(QApplication::translate("Continuance", "CANCEL", 0, QApplication::UnicodeUTF8));
        toolButton_Update->setText(QApplication::translate("Continuance", "CONTINUE", 0, QApplication::UnicodeUTF8));
        label_Title->setText(QApplication::translate("Continuance", "CONFIRMATION: CASE CONTINUANCE", 0, QApplication::UnicodeUTF8));
        label_4->setText(QApplication::translate("Continuance", "Continuance Time", 0, QApplication::UnicodeUTF8));
        label_3->setText(QApplication::translate("Continuance", "Continuance Date", 0, QApplication::UnicodeUTF8));
        label_2->setText(QApplication::translate("Continuance", "Case Number", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("Continuance", "Enter the new docket date the requesting party and the reason below and Update to set to case hearing date and populate court form.", 0, QApplication::UnicodeUTF8));
        comboBox_Department->clear();
        comboBox_Department->insertItems(0, QStringList()
         << QApplication::translate("Continuance", "G1", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Continuance", "G2", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Continuance", "G3", 0, QApplication::UnicodeUTF8)
        );
        comboBox_Courtroom->clear();
        comboBox_Courtroom->insertItems(0, QStringList()
         << QApplication::translate("Continuance", "Courtroom A", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Continuance", "Courtroom B", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Continuance", "Courtroom C", 0, QApplication::UnicodeUTF8)
        );
        label_requestParty->setText(QApplication::translate("Continuance", "Requesting Party", 0, QApplication::UnicodeUTF8));
        comboBox_requestParty->clear();
        comboBox_requestParty->insertItems(0, QStringList()
         << QApplication::translate("Continuance", "Party 1", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Continuance", "Party 2", 0, QApplication::UnicodeUTF8)
        );
        label_reason->setText(QApplication::translate("Continuance", "Reason", 0, QApplication::UnicodeUTF8));
        comboBox_reason->clear();
        comboBox_reason->insertItems(0, QStringList()
         << QApplication::translate("Continuance", "POS Not Made", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Continuance", "Show Cause of Motion", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Continuance", "Other Reason", 0, QApplication::UnicodeUTF8)
        );
        label_reason_2->setText(QApplication::translate("Continuance", "Other", 0, QApplication::UnicodeUTF8));
        label_5->setText(QApplication::translate("Continuance", "Department", 0, QApplication::UnicodeUTF8));
        label_6->setText(QApplication::translate("Continuance", "Courtroom", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class Continuance: public Ui_Continuance {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CONTINUANCE_H
