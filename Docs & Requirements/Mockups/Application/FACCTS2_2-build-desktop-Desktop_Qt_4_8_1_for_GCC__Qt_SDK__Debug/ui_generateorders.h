/********************************************************************************
** Form generated from reading UI file 'generateorders.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_GENERATEORDERS_H
#define UI_GENERATEORDERS_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QCheckBox>
#include <QtGui/QComboBox>
#include <QtGui/QDialog>
#include <QtGui/QFrame>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QToolButton>

QT_BEGIN_NAMESPACE

class Ui_generateOrders
{
public:
    QLabel *label_generateTitle;
    QFrame *line;
    QToolButton *toolButton;
    QToolButton *toolButton_2;
    QFrame *line_2;
    QLineEdit *lineEdit_caseNumber;
    QLabel *label;
    QLabel *label_2;
    QComboBox *comboBox_masterOrder;
    QFrame *frame_attachments;
    QCheckBox *checkBox_generateDV140;
    QCheckBox *checkBox_generateDV145;
    QCheckBox *checkBox_generateDV150;
    QCheckBox *checkBox_generateFL340;
    QCheckBox *checkBox_generateFL341;
    QCheckBox *checkBox_otherForm;
    QLineEdit *lineEdit_otherAttach1;
    QLineEdit *lineEdit_otherAttach2;
    QLabel *label_3;
    QLabel *label_4;
    QCheckBox *checkBox_generateFL342;
    QCheckBox *checkBox_generateFL343;
    QLabel *label_5;
    QLabel *label_6;
    QCheckBox *checkBox_DV730;
    QCheckBox *checkBox_DV115;
    QCheckBox *checkBox_DV116;
    QToolButton *toolButton_eSign;

    void setupUi(QDialog *generateOrders)
    {
        if (generateOrders->objectName().isEmpty())
            generateOrders->setObjectName(QString::fromUtf8("generateOrders"));
        generateOrders->resize(596, 439);
        QFont font;
        font.setPointSize(11);
        generateOrders->setFont(font);
        label_generateTitle = new QLabel(generateOrders);
        label_generateTitle->setObjectName(QString::fromUtf8("label_generateTitle"));
        label_generateTitle->setGeometry(QRect(45, 65, 266, 23));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_generateTitle->setFont(font1);
        line = new QFrame(generateOrders);
        line->setObjectName(QString::fromUtf8("line"));
        line->setGeometry(QRect(45, 75, 466, 21));
        line->setFrameShape(QFrame::HLine);
        line->setFrameShadow(QFrame::Sunken);
        toolButton = new QToolButton(generateOrders);
        toolButton->setObjectName(QString::fromUtf8("toolButton"));
        toolButton->setGeometry(QRect(510, 400, 66, 23));
        toolButton_2 = new QToolButton(generateOrders);
        toolButton_2->setObjectName(QString::fromUtf8("toolButton_2"));
        toolButton_2->setGeometry(QRect(390, 400, 116, 23));
        line_2 = new QFrame(generateOrders);
        line_2->setObjectName(QString::fromUtf8("line_2"));
        line_2->setGeometry(QRect(110, 380, 466, 21));
        line_2->setFrameShape(QFrame::HLine);
        line_2->setFrameShadow(QFrame::Sunken);
        lineEdit_caseNumber = new QLineEdit(generateOrders);
        lineEdit_caseNumber->setObjectName(QString::fromUtf8("lineEdit_caseNumber"));
        lineEdit_caseNumber->setGeometry(QRect(170, 90, 113, 21));
        label = new QLabel(generateOrders);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(75, 90, 86, 21));
        label->setFont(font1);
        label_2 = new QLabel(generateOrders);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(75, 120, 86, 21));
        label_2->setFont(font1);
        comboBox_masterOrder = new QComboBox(generateOrders);
        comboBox_masterOrder->setObjectName(QString::fromUtf8("comboBox_masterOrder"));
        comboBox_masterOrder->setGeometry(QRect(170, 117, 116, 23));
        frame_attachments = new QFrame(generateOrders);
        frame_attachments->setObjectName(QString::fromUtf8("frame_attachments"));
        frame_attachments->setGeometry(QRect(175, 155, 331, 136));
        frame_attachments->setFrameShape(QFrame::StyledPanel);
        frame_attachments->setFrameShadow(QFrame::Raised);
        checkBox_generateDV140 = new QCheckBox(frame_attachments);
        checkBox_generateDV140->setObjectName(QString::fromUtf8("checkBox_generateDV140"));
        checkBox_generateDV140->setGeometry(QRect(10, 5, 146, 20));
        checkBox_generateDV145 = new QCheckBox(frame_attachments);
        checkBox_generateDV145->setObjectName(QString::fromUtf8("checkBox_generateDV145"));
        checkBox_generateDV145->setGeometry(QRect(10, 30, 141, 20));
        checkBox_generateDV150 = new QCheckBox(frame_attachments);
        checkBox_generateDV150->setObjectName(QString::fromUtf8("checkBox_generateDV150"));
        checkBox_generateDV150->setGeometry(QRect(10, 55, 136, 20));
        checkBox_generateFL340 = new QCheckBox(frame_attachments);
        checkBox_generateFL340->setObjectName(QString::fromUtf8("checkBox_generateFL340"));
        checkBox_generateFL340->setGeometry(QRect(156, 5, 76, 20));
        checkBox_generateFL341 = new QCheckBox(frame_attachments);
        checkBox_generateFL341->setObjectName(QString::fromUtf8("checkBox_generateFL341"));
        checkBox_generateFL341->setGeometry(QRect(156, 30, 71, 20));
        checkBox_otherForm = new QCheckBox(frame_attachments);
        checkBox_otherForm->setObjectName(QString::fromUtf8("checkBox_otherForm"));
        checkBox_otherForm->setGeometry(QRect(156, 55, 156, 20));
        lineEdit_otherAttach1 = new QLineEdit(frame_attachments);
        lineEdit_otherAttach1->setObjectName(QString::fromUtf8("lineEdit_otherAttach1"));
        lineEdit_otherAttach1->setGeometry(QRect(130, 80, 191, 21));
        lineEdit_otherAttach2 = new QLineEdit(frame_attachments);
        lineEdit_otherAttach2->setObjectName(QString::fromUtf8("lineEdit_otherAttach2"));
        lineEdit_otherAttach2->setGeometry(QRect(130, 105, 191, 21));
        label_3 = new QLabel(frame_attachments);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(15, 80, 121, 23));
        label_3->setFont(font);
        label_4 = new QLabel(frame_attachments);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(15, 105, 121, 23));
        label_4->setFont(font);
        checkBox_generateFL342 = new QCheckBox(frame_attachments);
        checkBox_generateFL342->setObjectName(QString::fromUtf8("checkBox_generateFL342"));
        checkBox_generateFL342->setGeometry(QRect(250, 5, 76, 20));
        checkBox_generateFL343 = new QCheckBox(frame_attachments);
        checkBox_generateFL343->setObjectName(QString::fromUtf8("checkBox_generateFL343"));
        checkBox_generateFL343->setGeometry(QRect(250, 30, 71, 20));
        label_5 = new QLabel(generateOrders);
        label_5->setObjectName(QString::fromUtf8("label_5"));
        label_5->setGeometry(QRect(75, 155, 86, 21));
        label_5->setFont(font1);
        label_6 = new QLabel(generateOrders);
        label_6->setObjectName(QString::fromUtf8("label_6"));
        label_6->setGeometry(QRect(80, 300, 86, 21));
        label_6->setFont(font1);
        checkBox_DV730 = new QCheckBox(generateOrders);
        checkBox_DV730->setObjectName(QString::fromUtf8("checkBox_DV730"));
        checkBox_DV730->setGeometry(QRect(185, 300, 201, 20));
        checkBox_DV115 = new QCheckBox(generateOrders);
        checkBox_DV115->setObjectName(QString::fromUtf8("checkBox_DV115"));
        checkBox_DV115->setGeometry(QRect(185, 325, 236, 20));
        checkBox_DV116 = new QCheckBox(generateOrders);
        checkBox_DV116->setObjectName(QString::fromUtf8("checkBox_DV116"));
        checkBox_DV116->setGeometry(QRect(185, 350, 236, 20));
        toolButton_eSign = new QToolButton(generateOrders);
        toolButton_eSign->setObjectName(QString::fromUtf8("toolButton_eSign"));
        toolButton_eSign->setGeometry(QRect(110, 400, 66, 23));

        retranslateUi(generateOrders);
        QObject::connect(toolButton, SIGNAL(clicked()), generateOrders, SLOT(close()));
        QObject::connect(toolButton_2, SIGNAL(clicked()), generateOrders, SLOT(accept()));

        QMetaObject::connectSlotsByName(generateOrders);
    } // setupUi

    void retranslateUi(QDialog *generateOrders)
    {
        generateOrders->setWindowTitle(QApplication::translate("generateOrders", "Generate Court Orders", 0, QApplication::UnicodeUTF8));
        label_generateTitle->setText(QApplication::translate("generateOrders", "GENERATE COURT ORDERS", 0, QApplication::UnicodeUTF8));
        toolButton->setText(QApplication::translate("generateOrders", "CANCEL", 0, QApplication::UnicodeUTF8));
        toolButton_2->setText(QApplication::translate("generateOrders", "SAVE AND PRINT", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("generateOrders", "Case Number", 0, QApplication::UnicodeUTF8));
        label_2->setText(QApplication::translate("generateOrders", "Master Order", 0, QApplication::UnicodeUTF8));
        comboBox_masterOrder->clear();
        comboBox_masterOrder->insertItems(0, QStringList()
         << QApplication::translate("generateOrders", "DV110", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("generateOrders", "DV130", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("generateOrders", "DV140", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("generateOrders", "CH110", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("generateOrders", "CH130", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("generateOrders", "EA110", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("generateOrders", "EA130", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("generateOrders", "Other Orders", 0, QApplication::UnicodeUTF8)
        );
        checkBox_generateDV140->setText(QApplication::translate("generateOrders", "DV140 CC - CV", 0, QApplication::UnicodeUTF8));
        checkBox_generateDV145->setText(QApplication::translate("generateOrders", "DV145 Travel Restrict", 0, QApplication::UnicodeUTF8));
        checkBox_generateDV150->setText(QApplication::translate("generateOrders", "DV150 Supervision", 0, QApplication::UnicodeUTF8));
        checkBox_generateFL340->setText(QApplication::translate("generateOrders", "FL340", 0, QApplication::UnicodeUTF8));
        checkBox_generateFL341->setText(QApplication::translate("generateOrders", "FL341", 0, QApplication::UnicodeUTF8));
        checkBox_otherForm->setText(QApplication::translate("generateOrders", "Other", 0, QApplication::UnicodeUTF8));
        label_3->setText(QApplication::translate("generateOrders", "Other Attachment 1", 0, QApplication::UnicodeUTF8));
        label_4->setText(QApplication::translate("generateOrders", "Other Attachment 2", 0, QApplication::UnicodeUTF8));
        checkBox_generateFL342->setText(QApplication::translate("generateOrders", "FL342", 0, QApplication::UnicodeUTF8));
        checkBox_generateFL343->setText(QApplication::translate("generateOrders", "FL343", 0, QApplication::UnicodeUTF8));
        label_5->setText(QApplication::translate("generateOrders", "Attachments", 0, QApplication::UnicodeUTF8));
        label_6->setText(QApplication::translate("generateOrders", "Other Orders", 0, QApplication::UnicodeUTF8));
        checkBox_DV730->setText(QApplication::translate("generateOrders", "DV730 - Renew Orders", 0, QApplication::UnicodeUTF8));
        checkBox_DV115->setText(QApplication::translate("generateOrders", "DV115 - Request for Continuance", 0, QApplication::UnicodeUTF8));
        checkBox_DV116->setText(QApplication::translate("generateOrders", "DV116 - Reissuance Orders", 0, QApplication::UnicodeUTF8));
        toolButton_eSign->setText(QApplication::translate("generateOrders", "eSIGN", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class generateOrders: public Ui_generateOrders {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_GENERATEORDERS_H
