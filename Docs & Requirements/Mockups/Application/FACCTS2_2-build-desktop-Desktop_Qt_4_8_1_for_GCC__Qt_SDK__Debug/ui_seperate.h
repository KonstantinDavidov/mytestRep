/********************************************************************************
** Form generated from reading UI file 'seperate.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_SEPERATE_H
#define UI_SEPERATE_H

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

class Ui_seperate
{
public:
    QToolButton *toolButton_saveCaseCancel;
    QLineEdit *lineEdit_caseNewID;
    QFrame *line_lowerConfirm;
    QLabel *label_saveCaseInstruction;
    QLabel *label_saveCaseConfirm;
    QToolButton *toolButton_saveCase;
    QFrame *frame_warnSaveCase;
    QFrame *line_mainConfirm;

    void setupUi(QDialog *seperate)
    {
        if (seperate->objectName().isEmpty())
            seperate->setObjectName(QString::fromUtf8("seperate"));
        seperate->resize(400, 208);
        QFont font;
        font.setPointSize(11);
        seperate->setFont(font);
        toolButton_saveCaseCancel = new QToolButton(seperate);
        toolButton_saveCaseCancel->setObjectName(QString::fromUtf8("toolButton_saveCaseCancel"));
        toolButton_saveCaseCancel->setGeometry(QRect(310, 160, 76, 23));
        lineEdit_caseNewID = new QLineEdit(seperate);
        lineEdit_caseNewID->setObjectName(QString::fromUtf8("lineEdit_caseNewID"));
        lineEdit_caseNewID->setGeometry(QRect(105, 125, 108, 21));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        lineEdit_caseNewID->setFont(font1);
        lineEdit_caseNewID->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        lineEdit_caseNewID->setReadOnly(true);
        line_lowerConfirm = new QFrame(seperate);
        line_lowerConfirm->setObjectName(QString::fromUtf8("line_lowerConfirm"));
        line_lowerConfirm->setGeometry(QRect(165, 145, 221, 16));
        line_lowerConfirm->setFrameShape(QFrame::HLine);
        line_lowerConfirm->setFrameShadow(QFrame::Sunken);
        label_saveCaseInstruction = new QLabel(seperate);
        label_saveCaseInstruction->setObjectName(QString::fromUtf8("label_saveCaseInstruction"));
        label_saveCaseInstruction->setGeometry(QRect(105, 80, 291, 36));
        label_saveCaseInstruction->setFont(font);
        label_saveCaseInstruction->setWordWrap(true);
        label_saveCaseConfirm = new QLabel(seperate);
        label_saveCaseConfirm->setObjectName(QString::fromUtf8("label_saveCaseConfirm"));
        label_saveCaseConfirm->setGeometry(QRect(85, 60, 251, 26));
        label_saveCaseConfirm->setFont(font1);
        toolButton_saveCase = new QToolButton(seperate);
        toolButton_saveCase->setObjectName(QString::fromUtf8("toolButton_saveCase"));
        toolButton_saveCase->setGeometry(QRect(230, 160, 76, 23));
        frame_warnSaveCase = new QFrame(seperate);
        frame_warnSaveCase->setObjectName(QString::fromUtf8("frame_warnSaveCase"));
        frame_warnSaveCase->setGeometry(QRect(30, 50, 53, 53));
        frame_warnSaveCase->setStyleSheet(QString::fromUtf8("background-image: url(:/new/prefix1/_images/warning_1.png);"));
        frame_warnSaveCase->setFrameShape(QFrame::NoFrame);
        frame_warnSaveCase->setFrameShadow(QFrame::Raised);
        line_mainConfirm = new QFrame(seperate);
        line_mainConfirm->setObjectName(QString::fromUtf8("line_mainConfirm"));
        line_mainConfirm->setGeometry(QRect(85, 75, 296, 16));
        line_mainConfirm->setFrameShape(QFrame::HLine);
        line_mainConfirm->setFrameShadow(QFrame::Sunken);

        retranslateUi(seperate);
        QObject::connect(toolButton_saveCase, SIGNAL(clicked()), seperate, SLOT(accept()));
        QObject::connect(toolButton_saveCaseCancel, SIGNAL(clicked()), seperate, SLOT(close()));

        QMetaObject::connectSlotsByName(seperate);
    } // setupUi

    void retranslateUi(QDialog *seperate)
    {
        seperate->setWindowTitle(QApplication::translate("seperate", "Separate Case", 0, QApplication::UnicodeUTF8));
        toolButton_saveCaseCancel->setText(QApplication::translate("seperate", "CANCEL", 0, QApplication::UnicodeUTF8));
        lineEdit_caseNewID->setText(QApplication::translate("seperate", "22-1111", 0, QApplication::UnicodeUTF8));
        label_saveCaseInstruction->setText(QApplication::translate("seperate", "Separate this case from the master case.", 0, QApplication::UnicodeUTF8));
        label_saveCaseConfirm->setText(QApplication::translate("seperate", "SEPARATE CASE - CONFIRMATION", 0, QApplication::UnicodeUTF8));
        toolButton_saveCase->setText(QApplication::translate("seperate", "SEPARATE", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class seperate: public Ui_seperate {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_SEPERATE_H
