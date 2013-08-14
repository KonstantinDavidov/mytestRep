/********************************************************************************
** Form generated from reading UI file 'casesave.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CASESAVE_H
#define UI_CASESAVE_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QDialog>
#include <QtGui/QFrame>
#include <QtGui/QHBoxLayout>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QToolButton>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_casesave
{
public:
    QWidget *layoutWidget;
    QHBoxLayout *horizontalLayout;
    QLabel *label;
    QLineEdit *lineEdit_caseNumber;
    QLabel *label_saveOrder;
    QLabel *label_saveOrderInstruction;
    QToolButton *toolButton_cancelSave;
    QToolButton *toolButton_saveRecord;
    QFrame *frame_warnSaveOrders;
    QFrame *line_mainSaveOrder;
    QFrame *line_lowerSaveOrder;

    void setupUi(QDialog *casesave)
    {
        if (casesave->objectName().isEmpty())
            casesave->setObjectName(QString::fromUtf8("casesave"));
        casesave->resize(400, 217);
        layoutWidget = new QWidget(casesave);
        layoutWidget->setObjectName(QString::fromUtf8("layoutWidget"));
        layoutWidget->setGeometry(QRect(95, 125, 236, 23));
        horizontalLayout = new QHBoxLayout(layoutWidget);
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        horizontalLayout->setContentsMargins(0, 0, 0, 0);
        label = new QLabel(layoutWidget);
        label->setObjectName(QString::fromUtf8("label"));
        QFont font;
        font.setPointSize(11);
        font.setBold(true);
        font.setWeight(75);
        label->setFont(font);

        horizontalLayout->addWidget(label);

        lineEdit_caseNumber = new QLineEdit(layoutWidget);
        lineEdit_caseNumber->setObjectName(QString::fromUtf8("lineEdit_caseNumber"));
        QFont font1;
        font1.setPointSize(11);
        lineEdit_caseNumber->setFont(font1);
        lineEdit_caseNumber->setReadOnly(true);

        horizontalLayout->addWidget(lineEdit_caseNumber);

        label_saveOrder = new QLabel(casesave);
        label_saveOrder->setObjectName(QString::fromUtf8("label_saveOrder"));
        label_saveOrder->setGeometry(QRect(85, 65, 250, 16));
        label_saveOrder->setFont(font);
        label_saveOrderInstruction = new QLabel(casesave);
        label_saveOrderInstruction->setObjectName(QString::fromUtf8("label_saveOrderInstruction"));
        label_saveOrderInstruction->setGeometry(QRect(95, 90, 256, 31));
        label_saveOrderInstruction->setFont(font1);
        label_saveOrderInstruction->setWordWrap(true);
        toolButton_cancelSave = new QToolButton(casesave);
        toolButton_cancelSave->setObjectName(QString::fromUtf8("toolButton_cancelSave"));
        toolButton_cancelSave->setGeometry(QRect(270, 165, 85, 23));
        toolButton_saveRecord = new QToolButton(casesave);
        toolButton_saveRecord->setObjectName(QString::fromUtf8("toolButton_saveRecord"));
        toolButton_saveRecord->setGeometry(QRect(180, 165, 85, 23));
        frame_warnSaveOrders = new QFrame(casesave);
        frame_warnSaveOrders->setObjectName(QString::fromUtf8("frame_warnSaveOrders"));
        frame_warnSaveOrders->setGeometry(QRect(30, 50, 53, 53));
        frame_warnSaveOrders->setStyleSheet(QString::fromUtf8("background-image: url(:/new/prefix1/_images/warning_1.png);"));
        frame_warnSaveOrders->setFrameShape(QFrame::NoFrame);
        frame_warnSaveOrders->setFrameShadow(QFrame::Raised);
        line_mainSaveOrder = new QFrame(casesave);
        line_mainSaveOrder->setObjectName(QString::fromUtf8("line_mainSaveOrder"));
        line_mainSaveOrder->setGeometry(QRect(85, 75, 286, 16));
        line_mainSaveOrder->setFrameShape(QFrame::HLine);
        line_mainSaveOrder->setFrameShadow(QFrame::Sunken);
        line_lowerSaveOrder = new QFrame(casesave);
        line_lowerSaveOrder->setObjectName(QString::fromUtf8("line_lowerSaveOrder"));
        line_lowerSaveOrder->setGeometry(QRect(145, 150, 216, 21));
        line_lowerSaveOrder->setFrameShape(QFrame::HLine);
        line_lowerSaveOrder->setFrameShadow(QFrame::Sunken);

        retranslateUi(casesave);
        QObject::connect(toolButton_cancelSave, SIGNAL(clicked()), casesave, SLOT(close()));

        QMetaObject::connectSlotsByName(casesave);
    } // setupUi

    void retranslateUi(QDialog *casesave)
    {
        casesave->setWindowTitle(QApplication::translate("casesave", "Save Case Record", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("casesave", "Case Number", 0, QApplication::UnicodeUTF8));
        lineEdit_caseNumber->setText(QString());
        label_saveOrder->setText(QApplication::translate("casesave", "CASE RECORD SAVE: CONFIRMATION", 0, QApplication::UnicodeUTF8));
        label_saveOrderInstruction->setText(QApplication::translate("casesave", "You are saving changes to the the case record are you sure ?", 0, QApplication::UnicodeUTF8));
        toolButton_cancelSave->setText(QApplication::translate("casesave", "CANCEL", 0, QApplication::UnicodeUTF8));
        toolButton_saveRecord->setText(QApplication::translate("casesave", "SAVE", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class casesave: public Ui_casesave {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CASESAVE_H
