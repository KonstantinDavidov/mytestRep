/********************************************************************************
** Form generated from reading UI file 'confirm.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CONFIRM_H
#define UI_CONFIRM_H

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

class Ui_Confirm
{
public:
    QToolButton *toolButton_saveCaseCancel;
    QToolButton *toolButton_saveCase;
    QLabel *label_saveCaseInstruction;
    QLabel *label_saveCaseConfirm;
    QFrame *line_mainConfirm;
    QFrame *frame_warnSaveCase;
    QFrame *line_lowerConfirm;
    QLineEdit *lineEdit_caseNewID;
    QFrame *frame_warnSaveCase_2;
    QFrame *line_lowerConfirm_2;
    QLineEdit *lineEdit_caseNewID_2;
    QLabel *label_saveCaseConfirm_2;
    QFrame *line_mainConfirm_2;
    QToolButton *toolButton_saveCase_2;
    QToolButton *toolButton_saveCaseCancel_2;
    QLabel *label_saveCaseInstruction_2;

    void setupUi(QDialog *Confirm)
    {
        if (Confirm->objectName().isEmpty())
            Confirm->setObjectName(QString::fromUtf8("Confirm"));
        Confirm->resize(400, 208);
        toolButton_saveCaseCancel = new QToolButton(Confirm);
        toolButton_saveCaseCancel->setObjectName(QString::fromUtf8("toolButton_saveCaseCancel"));
        toolButton_saveCaseCancel->setGeometry(QRect(310, 160, 76, 23));
        toolButton_saveCase = new QToolButton(Confirm);
        toolButton_saveCase->setObjectName(QString::fromUtf8("toolButton_saveCase"));
        toolButton_saveCase->setGeometry(QRect(230, 160, 76, 23));
        label_saveCaseInstruction = new QLabel(Confirm);
        label_saveCaseInstruction->setObjectName(QString::fromUtf8("label_saveCaseInstruction"));
        label_saveCaseInstruction->setGeometry(QRect(105, 85, 261, 36));
        QFont font;
        font.setPointSize(11);
        label_saveCaseInstruction->setFont(font);
        label_saveCaseInstruction->setWordWrap(true);
        label_saveCaseConfirm = new QLabel(Confirm);
        label_saveCaseConfirm->setObjectName(QString::fromUtf8("label_saveCaseConfirm"));
        label_saveCaseConfirm->setGeometry(QRect(85, 60, 251, 26));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_saveCaseConfirm->setFont(font1);
        line_mainConfirm = new QFrame(Confirm);
        line_mainConfirm->setObjectName(QString::fromUtf8("line_mainConfirm"));
        line_mainConfirm->setGeometry(QRect(85, 75, 296, 16));
        line_mainConfirm->setFrameShape(QFrame::HLine);
        line_mainConfirm->setFrameShadow(QFrame::Sunken);
        frame_warnSaveCase = new QFrame(Confirm);
        frame_warnSaveCase->setObjectName(QString::fromUtf8("frame_warnSaveCase"));
        frame_warnSaveCase->setGeometry(QRect(30, 50, 53, 53));
        frame_warnSaveCase->setStyleSheet(QString::fromUtf8("background-image: url(:/new/prefix1/_images/warning_1.png);"));
        frame_warnSaveCase->setFrameShape(QFrame::NoFrame);
        frame_warnSaveCase->setFrameShadow(QFrame::Raised);
        line_lowerConfirm = new QFrame(Confirm);
        line_lowerConfirm->setObjectName(QString::fromUtf8("line_lowerConfirm"));
        line_lowerConfirm->setGeometry(QRect(165, 145, 221, 16));
        line_lowerConfirm->setFrameShape(QFrame::HLine);
        line_lowerConfirm->setFrameShadow(QFrame::Sunken);
        lineEdit_caseNewID = new QLineEdit(Confirm);
        lineEdit_caseNewID->setObjectName(QString::fromUtf8("lineEdit_caseNewID"));
        lineEdit_caseNewID->setGeometry(QRect(105, 125, 108, 21));
        lineEdit_caseNewID->setFont(font1);
        lineEdit_caseNewID->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        lineEdit_caseNewID->setReadOnly(true);
        frame_warnSaveCase_2 = new QFrame(Confirm);
        frame_warnSaveCase_2->setObjectName(QString::fromUtf8("frame_warnSaveCase_2"));
        frame_warnSaveCase_2->setGeometry(QRect(0, 0, 53, 53));
        frame_warnSaveCase_2->setStyleSheet(QString::fromUtf8("background-image: url(:/new/prefix1/_images/warning_1.png);"));
        frame_warnSaveCase_2->setFrameShape(QFrame::NoFrame);
        frame_warnSaveCase_2->setFrameShadow(QFrame::Raised);
        line_lowerConfirm_2 = new QFrame(Confirm);
        line_lowerConfirm_2->setObjectName(QString::fromUtf8("line_lowerConfirm_2"));
        line_lowerConfirm_2->setGeometry(QRect(135, 95, 221, 16));
        line_lowerConfirm_2->setFrameShape(QFrame::HLine);
        line_lowerConfirm_2->setFrameShadow(QFrame::Sunken);
        lineEdit_caseNewID_2 = new QLineEdit(Confirm);
        lineEdit_caseNewID_2->setObjectName(QString::fromUtf8("lineEdit_caseNewID_2"));
        lineEdit_caseNewID_2->setGeometry(QRect(75, 75, 108, 21));
        lineEdit_caseNewID_2->setFont(font1);
        lineEdit_caseNewID_2->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        lineEdit_caseNewID_2->setReadOnly(true);
        label_saveCaseConfirm_2 = new QLabel(Confirm);
        label_saveCaseConfirm_2->setObjectName(QString::fromUtf8("label_saveCaseConfirm_2"));
        label_saveCaseConfirm_2->setGeometry(QRect(55, 10, 251, 26));
        label_saveCaseConfirm_2->setFont(font1);
        line_mainConfirm_2 = new QFrame(Confirm);
        line_mainConfirm_2->setObjectName(QString::fromUtf8("line_mainConfirm_2"));
        line_mainConfirm_2->setGeometry(QRect(55, 25, 296, 16));
        line_mainConfirm_2->setFrameShape(QFrame::HLine);
        line_mainConfirm_2->setFrameShadow(QFrame::Sunken);
        toolButton_saveCase_2 = new QToolButton(Confirm);
        toolButton_saveCase_2->setObjectName(QString::fromUtf8("toolButton_saveCase_2"));
        toolButton_saveCase_2->setGeometry(QRect(200, 110, 76, 23));
        toolButton_saveCaseCancel_2 = new QToolButton(Confirm);
        toolButton_saveCaseCancel_2->setObjectName(QString::fromUtf8("toolButton_saveCaseCancel_2"));
        toolButton_saveCaseCancel_2->setGeometry(QRect(280, 110, 76, 23));
        label_saveCaseInstruction_2 = new QLabel(Confirm);
        label_saveCaseInstruction_2->setObjectName(QString::fromUtf8("label_saveCaseInstruction_2"));
        label_saveCaseInstruction_2->setGeometry(QRect(75, 35, 261, 36));
        label_saveCaseInstruction_2->setFont(font);
        label_saveCaseInstruction_2->setWordWrap(true);

        retranslateUi(Confirm);
        QObject::connect(toolButton_saveCaseCancel, SIGNAL(clicked()), Confirm, SLOT(close()));
        QObject::connect(toolButton_saveCase, SIGNAL(clicked()), Confirm, SLOT(accept()));

        QMetaObject::connectSlotsByName(Confirm);
    } // setupUi

    void retranslateUi(QDialog *Confirm)
    {
        Confirm->setWindowTitle(QApplication::translate("Confirm", "Confirm Drop Case", 0, QApplication::UnicodeUTF8));
        toolButton_saveCaseCancel->setText(QApplication::translate("Confirm", "CANCEL", 0, QApplication::UnicodeUTF8));
        toolButton_saveCase->setText(QApplication::translate("Confirm", "DROP", 0, QApplication::UnicodeUTF8));
        label_saveCaseInstruction->setText(QApplication::translate("Confirm", "You are about to DROP this case and remove it from active status and all future dockets.", 0, QApplication::UnicodeUTF8));
        label_saveCaseConfirm->setText(QApplication::translate("Confirm", "DROP CASE - CONFIRMATION", 0, QApplication::UnicodeUTF8));
        lineEdit_caseNewID->setText(QApplication::translate("Confirm", "22-1251", 0, QApplication::UnicodeUTF8));
        lineEdit_caseNewID_2->setText(QApplication::translate("Confirm", "22-1251", 0, QApplication::UnicodeUTF8));
        label_saveCaseConfirm_2->setText(QApplication::translate("Confirm", "DROP CASE - CONFIRMATION", 0, QApplication::UnicodeUTF8));
        toolButton_saveCase_2->setText(QApplication::translate("Confirm", "DROP", 0, QApplication::UnicodeUTF8));
        toolButton_saveCaseCancel_2->setText(QApplication::translate("Confirm", "CANCEL", 0, QApplication::UnicodeUTF8));
        label_saveCaseInstruction_2->setText(QApplication::translate("Confirm", "You are about to DROP this case and remove it from active status and all future dockets.", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class Confirm: public Ui_Confirm {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CONFIRM_H
