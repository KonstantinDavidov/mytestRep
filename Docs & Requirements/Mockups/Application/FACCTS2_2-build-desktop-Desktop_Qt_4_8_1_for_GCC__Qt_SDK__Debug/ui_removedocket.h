/********************************************************************************
** Form generated from reading UI file 'removedocket.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_REMOVEDOCKET_H
#define UI_REMOVEDOCKET_H

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

class Ui_removedocket
{
public:
    QFrame *frame_warnSaveCase;
    QFrame *line_lowerConfirm;
    QLineEdit *lineEdit_caseNumber;
    QLabel *label_saveCaseConfirm;
    QFrame *line_mainConfirm;
    QToolButton *toolButton_saveCase;
    QToolButton *toolButton_saveCaseCancel;
    QLabel *label_saveCaseInstruction;
    QLineEdit *lineEdit_Reason;
    QLabel *label;
    QLabel *label_2;

    void setupUi(QDialog *removedocket)
    {
        if (removedocket->objectName().isEmpty())
            removedocket->setObjectName(QString::fromUtf8("removedocket"));
        removedocket->resize(414, 233);
        QFont font;
        font.setPointSize(11);
        removedocket->setFont(font);
        frame_warnSaveCase = new QFrame(removedocket);
        frame_warnSaveCase->setObjectName(QString::fromUtf8("frame_warnSaveCase"));
        frame_warnSaveCase->setGeometry(QRect(30, 50, 53, 53));
        frame_warnSaveCase->setStyleSheet(QString::fromUtf8("background-image: url(:/new/prefix1/_images/warning_1.png);"));
        frame_warnSaveCase->setFrameShape(QFrame::NoFrame);
        frame_warnSaveCase->setFrameShadow(QFrame::Raised);
        line_lowerConfirm = new QFrame(removedocket);
        line_lowerConfirm->setObjectName(QString::fromUtf8("line_lowerConfirm"));
        line_lowerConfirm->setGeometry(QRect(165, 175, 221, 16));
        line_lowerConfirm->setFrameShape(QFrame::HLine);
        line_lowerConfirm->setFrameShadow(QFrame::Sunken);
        lineEdit_caseNumber = new QLineEdit(removedocket);
        lineEdit_caseNumber->setObjectName(QString::fromUtf8("lineEdit_caseNumber"));
        lineEdit_caseNumber->setGeometry(QRect(105, 135, 91, 21));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        lineEdit_caseNumber->setFont(font1);
        lineEdit_caseNumber->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        lineEdit_caseNumber->setReadOnly(true);
        label_saveCaseConfirm = new QLabel(removedocket);
        label_saveCaseConfirm->setObjectName(QString::fromUtf8("label_saveCaseConfirm"));
        label_saveCaseConfirm->setGeometry(QRect(85, 60, 251, 26));
        label_saveCaseConfirm->setFont(font1);
        line_mainConfirm = new QFrame(removedocket);
        line_mainConfirm->setObjectName(QString::fromUtf8("line_mainConfirm"));
        line_mainConfirm->setGeometry(QRect(85, 75, 296, 16));
        line_mainConfirm->setFrameShape(QFrame::HLine);
        line_mainConfirm->setFrameShadow(QFrame::Sunken);
        toolButton_saveCase = new QToolButton(removedocket);
        toolButton_saveCase->setObjectName(QString::fromUtf8("toolButton_saveCase"));
        toolButton_saveCase->setGeometry(QRect(230, 190, 76, 23));
        toolButton_saveCaseCancel = new QToolButton(removedocket);
        toolButton_saveCaseCancel->setObjectName(QString::fromUtf8("toolButton_saveCaseCancel"));
        toolButton_saveCaseCancel->setGeometry(QRect(310, 190, 76, 23));
        label_saveCaseInstruction = new QLabel(removedocket);
        label_saveCaseInstruction->setObjectName(QString::fromUtf8("label_saveCaseInstruction"));
        label_saveCaseInstruction->setGeometry(QRect(105, 90, 281, 41));
        label_saveCaseInstruction->setFont(font);
        label_saveCaseInstruction->setWordWrap(true);
        lineEdit_Reason = new QLineEdit(removedocket);
        lineEdit_Reason->setObjectName(QString::fromUtf8("lineEdit_Reason"));
        lineEdit_Reason->setGeometry(QRect(200, 135, 186, 21));
        label = new QLabel(removedocket);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(105, 155, 91, 18));
        label->setFont(font);
        label->setAlignment(Qt::AlignCenter);
        label_2 = new QLabel(removedocket);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(195, 155, 191, 18));
        label_2->setFont(font);
        label_2->setAlignment(Qt::AlignCenter);

        retranslateUi(removedocket);
        QObject::connect(toolButton_saveCaseCancel, SIGNAL(clicked()), removedocket, SLOT(close()));

        QMetaObject::connectSlotsByName(removedocket);
    } // setupUi

    void retranslateUi(QDialog *removedocket)
    {
        removedocket->setWindowTitle(QApplication::translate("removedocket", "Remove Case From Docket", 0, QApplication::UnicodeUTF8));
        lineEdit_caseNumber->setText(QString());
        label_saveCaseConfirm->setText(QApplication::translate("removedocket", "REMOVE CASE DOCKET - CONFIRMATION", 0, QApplication::UnicodeUTF8));
        toolButton_saveCase->setText(QApplication::translate("removedocket", "REMOVE", 0, QApplication::UnicodeUTF8));
        toolButton_saveCaseCancel->setText(QApplication::translate("removedocket", "CANCEL", 0, QApplication::UnicodeUTF8));
        label_saveCaseInstruction->setText(QApplication::translate("removedocket", "You are about to REMOVE this CASE from the CURRENT DOCKET.  Please Confirm Case Number and reason.", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("removedocket", "Case Number", 0, QApplication::UnicodeUTF8));
        label_2->setText(QApplication::translate("removedocket", "Reason", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class removedocket: public Ui_removedocket {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_REMOVEDOCKET_H
