/********************************************************************************
** Form generated from reading UI file 'export.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_EXPORT_H
#define UI_EXPORT_H

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

class Ui_Export
{
public:
    QToolButton *toolButton_exportCancel;
    QToolButton *toolButton_exportAccept;
    QFrame *frame_CASE_NUM_EXPORT;
    QLineEdit *lineEdit_Export_CaseNumber;
    QToolButton *toolButton_exportCaseNumberEdit;
    QLabel *label_exportCaseNumber;
    QFrame *frame_AGENCY_EXPORT;
    QLineEdit *lineEdit_ORINumber;
    QComboBox *comboBox_AgencyORISelect;
    QLabel *label_ExportInstructions;
    QFrame *line_lowerExportCase;
    QFrame *line_mainExportCase;
    QLabel *label_exportTitle;

    void setupUi(QDialog *Export)
    {
        if (Export->objectName().isEmpty())
            Export->setObjectName(QString::fromUtf8("Export"));
        Export->resize(453, 267);
        QFont font;
        font.setPointSize(11);
        Export->setFont(font);
        toolButton_exportCancel = new QToolButton(Export);
        toolButton_exportCancel->setObjectName(QString::fromUtf8("toolButton_exportCancel"));
        toolButton_exportCancel->setGeometry(QRect(350, 225, 85, 23));
        toolButton_exportAccept = new QToolButton(Export);
        toolButton_exportAccept->setObjectName(QString::fromUtf8("toolButton_exportAccept"));
        toolButton_exportAccept->setGeometry(QRect(255, 225, 85, 23));
        frame_CASE_NUM_EXPORT = new QFrame(Export);
        frame_CASE_NUM_EXPORT->setObjectName(QString::fromUtf8("frame_CASE_NUM_EXPORT"));
        frame_CASE_NUM_EXPORT->setGeometry(QRect(30, 130, 406, 41));
        frame_CASE_NUM_EXPORT->setFrameShape(QFrame::StyledPanel);
        frame_CASE_NUM_EXPORT->setFrameShadow(QFrame::Raised);
        lineEdit_Export_CaseNumber = new QLineEdit(frame_CASE_NUM_EXPORT);
        lineEdit_Export_CaseNumber->setObjectName(QString::fromUtf8("lineEdit_Export_CaseNumber"));
        lineEdit_Export_CaseNumber->setGeometry(QRect(145, 10, 161, 22));
        toolButton_exportCaseNumberEdit = new QToolButton(frame_CASE_NUM_EXPORT);
        toolButton_exportCaseNumberEdit->setObjectName(QString::fromUtf8("toolButton_exportCaseNumberEdit"));
        toolButton_exportCaseNumberEdit->setGeometry(QRect(310, 10, 66, 23));
        label_exportCaseNumber = new QLabel(frame_CASE_NUM_EXPORT);
        label_exportCaseNumber->setObjectName(QString::fromUtf8("label_exportCaseNumber"));
        label_exportCaseNumber->setGeometry(QRect(15, 10, 121, 23));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_exportCaseNumber->setFont(font1);
        frame_AGENCY_EXPORT = new QFrame(Export);
        frame_AGENCY_EXPORT->setObjectName(QString::fromUtf8("frame_AGENCY_EXPORT"));
        frame_AGENCY_EXPORT->setGeometry(QRect(30, 175, 406, 36));
        frame_AGENCY_EXPORT->setFrameShape(QFrame::StyledPanel);
        frame_AGENCY_EXPORT->setFrameShadow(QFrame::Raised);
        lineEdit_ORINumber = new QLineEdit(frame_AGENCY_EXPORT);
        lineEdit_ORINumber->setObjectName(QString::fromUtf8("lineEdit_ORINumber"));
        lineEdit_ORINumber->setGeometry(QRect(215, 5, 161, 22));
        comboBox_AgencyORISelect = new QComboBox(frame_AGENCY_EXPORT);
        comboBox_AgencyORISelect->setObjectName(QString::fromUtf8("comboBox_AgencyORISelect"));
        comboBox_AgencyORISelect->setGeometry(QRect(10, 5, 201, 23));
        label_ExportInstructions = new QLabel(Export);
        label_ExportInstructions->setObjectName(QString::fromUtf8("label_ExportInstructions"));
        label_ExportInstructions->setGeometry(QRect(75, 75, 366, 46));
        label_ExportInstructions->setFont(font);
        label_ExportInstructions->setWordWrap(true);
        line_lowerExportCase = new QFrame(Export);
        line_lowerExportCase->setObjectName(QString::fromUtf8("line_lowerExportCase"));
        line_lowerExportCase->setGeometry(QRect(235, 210, 211, 16));
        line_lowerExportCase->setFrameShape(QFrame::HLine);
        line_lowerExportCase->setFrameShadow(QFrame::Sunken);
        line_mainExportCase = new QFrame(Export);
        line_mainExportCase->setObjectName(QString::fromUtf8("line_mainExportCase"));
        line_mainExportCase->setGeometry(QRect(35, 65, 396, 16));
        line_mainExportCase->setFrameShape(QFrame::HLine);
        line_mainExportCase->setFrameShadow(QFrame::Sunken);
        label_exportTitle = new QLabel(Export);
        label_exportTitle->setObjectName(QString::fromUtf8("label_exportTitle"));
        label_exportTitle->setGeometry(QRect(35, 50, 371, 23));
        label_exportTitle->setFont(font1);

        retranslateUi(Export);
        QObject::connect(toolButton_exportCancel, SIGNAL(clicked()), Export, SLOT(close()));
        QObject::connect(toolButton_exportAccept, SIGNAL(clicked()), Export, SLOT(accept()));

        QMetaObject::connectSlotsByName(Export);
    } // setupUi

    void retranslateUi(QDialog *Export)
    {
        Export->setWindowTitle(QApplication::translate("Export", "CCPOR Export", 0, QApplication::UnicodeUTF8));
        toolButton_exportCancel->setText(QApplication::translate("Export", "CANCEL", 0, QApplication::UnicodeUTF8));
        toolButton_exportAccept->setText(QApplication::translate("Export", "EXPORT", 0, QApplication::UnicodeUTF8));
        lineEdit_Export_CaseNumber->setText(QString());
        toolButton_exportCaseNumberEdit->setText(QApplication::translate("Export", "EDIT", 0, QApplication::UnicodeUTF8));
        label_exportCaseNumber->setText(QApplication::translate("Export", "Originating Case #", 0, QApplication::UnicodeUTF8));
        lineEdit_ORINumber->setText(QApplication::translate("Export", "CA0540600", 0, QApplication::UnicodeUTF8));
        comboBox_AgencyORISelect->clear();
        comboBox_AgencyORISelect->insertItems(0, QStringList()
         << QApplication::translate("Export", "Test Environment", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Export", "Orange County Sheriffs Office", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Export", "Irvine Police Department", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Export", "Newport Beach Police Department", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("Export", "Santa Ana Police Department", 0, QApplication::UnicodeUTF8)
        );
        label_ExportInstructions->setText(QApplication::translate("Export", "Export to CCPOR Requires Agency ORI information and originating case number please confirm the FACCTS case number will be used or edit the case number and select the Agency ORI", 0, QApplication::UnicodeUTF8));
        label_exportTitle->setText(QApplication::translate("Export", "EXPORT CASE TO CCPOR - CASE ORIGINATION DATA INPUT", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class Export: public Ui_Export {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_EXPORT_H
