/********************************************************************************
** Form generated from reading UI file 'casestatus.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CASESTATUS_H
#define UI_CASESTATUS_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QComboBox>
#include <QtGui/QDialog>
#include <QtGui/QFrame>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QToolButton>

QT_BEGIN_NAMESPACE

class Ui_casestatus
{
public:
    QToolButton *toolButton_statusCancel;
    QLabel *label_statusUpdateInstructions;
    QLabel *label_statusUpdateConfirm;
    QFrame *line_mainConfirm;
    QFrame *line_lowerConfirm;
    QLineEdit *lineEdit_caseStatusUpdate;
    QToolButton *toolButton_statusUpdate;
    QFrame *frame_warnSaveCase;
    QComboBox *comboBox_statusUpdate;

    void setupUi(QDialog *casestatus)
    {
        if (casestatus->objectName().isEmpty())
            casestatus->setObjectName(QString::fromUtf8("casestatus"));
        casestatus->resize(400, 208);
        QFont font;
        font.setPointSize(11);
        casestatus->setFont(font);
        toolButton_statusCancel = new QToolButton(casestatus);
        toolButton_statusCancel->setObjectName(QString::fromUtf8("toolButton_statusCancel"));
        toolButton_statusCancel->setGeometry(QRect(310, 160, 76, 23));
        label_statusUpdateInstructions = new QLabel(casestatus);
        label_statusUpdateInstructions->setObjectName(QString::fromUtf8("label_statusUpdateInstructions"));
        label_statusUpdateInstructions->setGeometry(QRect(105, 85, 261, 36));
        label_statusUpdateInstructions->setFont(font);
        label_statusUpdateInstructions->setWordWrap(true);
        label_statusUpdateConfirm = new QLabel(casestatus);
        label_statusUpdateConfirm->setObjectName(QString::fromUtf8("label_statusUpdateConfirm"));
        label_statusUpdateConfirm->setGeometry(QRect(85, 60, 251, 26));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_statusUpdateConfirm->setFont(font1);
        line_mainConfirm = new QFrame(casestatus);
        line_mainConfirm->setObjectName(QString::fromUtf8("line_mainConfirm"));
        line_mainConfirm->setGeometry(QRect(85, 75, 296, 16));
        line_mainConfirm->setFrameShape(QFrame::HLine);
        line_mainConfirm->setFrameShadow(QFrame::Sunken);
        line_lowerConfirm = new QFrame(casestatus);
        line_lowerConfirm->setObjectName(QString::fromUtf8("line_lowerConfirm"));
        line_lowerConfirm->setGeometry(QRect(165, 145, 221, 16));
        line_lowerConfirm->setFrameShape(QFrame::HLine);
        line_lowerConfirm->setFrameShadow(QFrame::Sunken);
        lineEdit_caseStatusUpdate = new QLineEdit(casestatus);
        lineEdit_caseStatusUpdate->setObjectName(QString::fromUtf8("lineEdit_caseStatusUpdate"));
        lineEdit_caseStatusUpdate->setGeometry(QRect(105, 125, 108, 21));
        lineEdit_caseStatusUpdate->setFont(font1);
        lineEdit_caseStatusUpdate->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        lineEdit_caseStatusUpdate->setReadOnly(true);
        toolButton_statusUpdate = new QToolButton(casestatus);
        toolButton_statusUpdate->setObjectName(QString::fromUtf8("toolButton_statusUpdate"));
        toolButton_statusUpdate->setGeometry(QRect(230, 160, 76, 23));
        frame_warnSaveCase = new QFrame(casestatus);
        frame_warnSaveCase->setObjectName(QString::fromUtf8("frame_warnSaveCase"));
        frame_warnSaveCase->setGeometry(QRect(30, 50, 53, 53));
        frame_warnSaveCase->setStyleSheet(QString::fromUtf8("background-image: url(:/new/prefix1/_images/warning_1.png);"));
        frame_warnSaveCase->setFrameShape(QFrame::NoFrame);
        frame_warnSaveCase->setFrameShadow(QFrame::Raised);
        comboBox_statusUpdate = new QComboBox(casestatus);
        comboBox_statusUpdate->setObjectName(QString::fromUtf8("comboBox_statusUpdate"));
        comboBox_statusUpdate->setGeometry(QRect(220, 125, 111, 23));
        comboBox_statusUpdate->setFont(font);

        retranslateUi(casestatus);
        QObject::connect(toolButton_statusCancel, SIGNAL(clicked()), casestatus, SLOT(close()));
        QObject::connect(toolButton_statusUpdate, SIGNAL(clicked()), casestatus, SLOT(accept()));

        QMetaObject::connectSlotsByName(casestatus);
    } // setupUi

    void retranslateUi(QDialog *casestatus)
    {
        casestatus->setWindowTitle(QApplication::translate("casestatus", "Case Status Update", 0, QApplication::UnicodeUTF8));
        toolButton_statusCancel->setText(QApplication::translate("casestatus", "CANCEL", 0, QApplication::UnicodeUTF8));
        label_statusUpdateInstructions->setText(QApplication::translate("casestatus", "To change the case status please confirm the case number and select the status change.  ", 0, QApplication::UnicodeUTF8));
        label_statusUpdateConfirm->setText(QApplication::translate("casestatus", "UPDATE STATUS - CONFIRMATION", 0, QApplication::UnicodeUTF8));
        lineEdit_caseStatusUpdate->setText(QApplication::translate("casestatus", "22-4331", 0, QApplication::UnicodeUTF8));
        toolButton_statusUpdate->setText(QApplication::translate("casestatus", "UPDATE", 0, QApplication::UnicodeUTF8));
        comboBox_statusUpdate->clear();
        comboBox_statusUpdate->insertItems(0, QStringList()
         << QApplication::translate("casestatus", "Active", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("casestatus", "Reissued", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("casestatus", "Drop", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("casestatus", "Dismiss", 0, QApplication::UnicodeUTF8)
        );
    } // retranslateUi

};

namespace Ui {
    class casestatus: public Ui_casestatus {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CASESTATUS_H
