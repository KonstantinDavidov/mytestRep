/********************************************************************************
** Form generated from reading UI file 'newcase.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_NEWCASE_H
#define UI_NEWCASE_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QDialog>
#include <QtGui/QFrame>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QToolButton>

QT_BEGIN_NAMESPACE

class Ui_newCase
{
public:
    QFrame *line_mainNewCase;
    QLabel *label_newCaseConfirm;
    QLabel *label_newCaseInstruction;
    QFrame *line_lowerNewCase;
    QLineEdit *lineEdit_caseNewID;
    QToolButton *toolButton_newCaseCreate;
    QToolButton *toolButton_newCaseCancel;
    QLabel *label_debug;

    void setupUi(QDialog *newCase)
    {
        if (newCase->objectName().isEmpty())
            newCase->setObjectName(QString::fromUtf8("newCase"));
        newCase->resize(400, 225);
        QFont font;
        font.setPointSize(11);
        newCase->setFont(font);
        line_mainNewCase = new QFrame(newCase);
        line_mainNewCase->setObjectName(QString::fromUtf8("line_mainNewCase"));
        line_mainNewCase->setGeometry(QRect(40, 75, 331, 16));
        line_mainNewCase->setFrameShape(QFrame::HLine);
        line_mainNewCase->setFrameShadow(QFrame::Sunken);
        label_newCaseConfirm = new QLabel(newCase);
        label_newCaseConfirm->setObjectName(QString::fromUtf8("label_newCaseConfirm"));
        label_newCaseConfirm->setGeometry(QRect(40, 60, 126, 26));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_newCaseConfirm->setFont(font1);
        label_newCaseInstruction = new QLabel(newCase);
        label_newCaseInstruction->setObjectName(QString::fromUtf8("label_newCaseInstruction"));
        label_newCaseInstruction->setGeometry(QRect(75, 85, 286, 41));
        label_newCaseInstruction->setFont(font);
        label_newCaseInstruction->setWordWrap(true);
        line_lowerNewCase = new QFrame(newCase);
        line_lowerNewCase->setObjectName(QString::fromUtf8("line_lowerNewCase"));
        line_lowerNewCase->setGeometry(QRect(175, 155, 216, 16));
        line_lowerNewCase->setFrameShape(QFrame::HLine);
        line_lowerNewCase->setFrameShadow(QFrame::Sunken);
        lineEdit_caseNewID = new QLineEdit(newCase);
        lineEdit_caseNewID->setObjectName(QString::fromUtf8("lineEdit_caseNewID"));
        lineEdit_caseNewID->setGeometry(QRect(76, 132, 121, 21));
        lineEdit_caseNewID->setFont(font1);
        lineEdit_caseNewID->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        lineEdit_caseNewID->setReadOnly(false);
        toolButton_newCaseCreate = new QToolButton(newCase);
        toolButton_newCaseCreate->setObjectName(QString::fromUtf8("toolButton_newCaseCreate"));
        toolButton_newCaseCreate->setGeometry(QRect(214, 171, 81, 23));
        toolButton_newCaseCancel = new QToolButton(newCase);
        toolButton_newCaseCancel->setObjectName(QString::fromUtf8("toolButton_newCaseCancel"));
        toolButton_newCaseCancel->setGeometry(QRect(301, 171, 81, 23));
        label_debug = new QLabel(newCase);
        label_debug->setObjectName(QString::fromUtf8("label_debug"));
        label_debug->setGeometry(QRect(30, 230, 361, 21));
        QFont font2;
        font2.setPointSize(10);
        label_debug->setFont(font2);

        retranslateUi(newCase);
        QObject::connect(toolButton_newCaseCancel, SIGNAL(clicked()), newCase, SLOT(close()));

        QMetaObject::connectSlotsByName(newCase);
    } // setupUi

    void retranslateUi(QDialog *newCase)
    {
        newCase->setWindowTitle(QApplication::translate("newCase", "Create New Case", 0, QApplication::UnicodeUTF8));
        label_newCaseConfirm->setText(QApplication::translate("newCase", "CREATE NEW CASE", 0, QApplication::UnicodeUTF8));
        label_newCaseInstruction->setText(QApplication::translate("newCase", "Please enter the Court Case Number to create a new case record in FACCTs", 0, QApplication::UnicodeUTF8));
        lineEdit_caseNewID->setText(QString());
        toolButton_newCaseCreate->setText(QApplication::translate("newCase", "CREATE CASE", 0, QApplication::UnicodeUTF8));
        toolButton_newCaseCancel->setText(QApplication::translate("newCase", "CANCEL", 0, QApplication::UnicodeUTF8));
        label_debug->setText(QApplication::translate("newCase", "Debug", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class newCase: public Ui_newCase {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_NEWCASE_H
