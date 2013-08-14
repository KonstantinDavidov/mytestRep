/********************************************************************************
** Form generated from reading UI file 'adddocket.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_ADDDOCKET_H
#define UI_ADDDOCKET_H

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
#include <QtGui/QVBoxLayout>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_adddocket
{
public:
    QToolButton *toolButton_docketAddCase;
    QToolButton *toolButton_docketAddCaseCancel;
    QFrame *line_lowerAddCaseDocket;
    QFrame *line_mainAddCaseDocket;
    QLabel *label_docketAddCaseTitle;
    QFrame *line;
    QLabel *label_6;
    QWidget *layoutWidget;
    QVBoxLayout *verticalLayout;
    QCheckBox *checkBox;
    QCheckBox *checkBox_2;
    QCheckBox *checkBox_3;
    QCheckBox *checkBox_4;
    QCheckBox *checkBox_5;
    QLineEdit *lineEdit;
    QLabel *label_3;
    QLineEdit *lineEdit_caseNumber;
    QLabel *label;
    QComboBox *comboBox_session;
    QLabel *label_2;
    QLabel *label_4;
    QComboBox *comboBox;
    QLabel *label_5;
    QComboBox *comboBox_2;

    void setupUi(QDialog *adddocket)
    {
        if (adddocket->objectName().isEmpty())
            adddocket->setObjectName(QString::fromUtf8("adddocket"));
        adddocket->resize(490, 269);
        QFont font;
        font.setPointSize(11);
        adddocket->setFont(font);
        toolButton_docketAddCase = new QToolButton(adddocket);
        toolButton_docketAddCase->setObjectName(QString::fromUtf8("toolButton_docketAddCase"));
        toolButton_docketAddCase->setGeometry(QRect(300, 230, 85, 23));
        toolButton_docketAddCaseCancel = new QToolButton(adddocket);
        toolButton_docketAddCaseCancel->setObjectName(QString::fromUtf8("toolButton_docketAddCaseCancel"));
        toolButton_docketAddCaseCancel->setGeometry(QRect(390, 230, 85, 23));
        line_lowerAddCaseDocket = new QFrame(adddocket);
        line_lowerAddCaseDocket->setObjectName(QString::fromUtf8("line_lowerAddCaseDocket"));
        line_lowerAddCaseDocket->setGeometry(QRect(130, 215, 346, 16));
        line_lowerAddCaseDocket->setFrameShape(QFrame::HLine);
        line_lowerAddCaseDocket->setFrameShadow(QFrame::Sunken);
        line_mainAddCaseDocket = new QFrame(adddocket);
        line_mainAddCaseDocket->setObjectName(QString::fromUtf8("line_mainAddCaseDocket"));
        line_mainAddCaseDocket->setGeometry(QRect(35, 55, 441, 16));
        line_mainAddCaseDocket->setFrameShape(QFrame::HLine);
        line_mainAddCaseDocket->setFrameShadow(QFrame::Sunken);
        label_docketAddCaseTitle = new QLabel(adddocket);
        label_docketAddCaseTitle->setObjectName(QString::fromUtf8("label_docketAddCaseTitle"));
        label_docketAddCaseTitle->setGeometry(QRect(35, 40, 226, 23));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_docketAddCaseTitle->setFont(font1);
        line = new QFrame(adddocket);
        line->setObjectName(QString::fromUtf8("line"));
        line->setGeometry(QRect(280, 70, 16, 146));
        line->setFrameShape(QFrame::VLine);
        line->setFrameShadow(QFrame::Sunken);
        label_6 = new QLabel(adddocket);
        label_6->setObjectName(QString::fromUtf8("label_6"));
        label_6->setGeometry(QRect(300, 65, 176, 23));
        label_6->setFont(font);
        layoutWidget = new QWidget(adddocket);
        layoutWidget->setObjectName(QString::fromUtf8("layoutWidget"));
        layoutWidget->setGeometry(QRect(300, 90, 176, 122));
        verticalLayout = new QVBoxLayout(layoutWidget);
        verticalLayout->setObjectName(QString::fromUtf8("verticalLayout"));
        verticalLayout->setContentsMargins(0, 0, 0, 0);
        checkBox = new QCheckBox(layoutWidget);
        checkBox->setObjectName(QString::fromUtf8("checkBox"));

        verticalLayout->addWidget(checkBox);

        checkBox_2 = new QCheckBox(layoutWidget);
        checkBox_2->setObjectName(QString::fromUtf8("checkBox_2"));

        verticalLayout->addWidget(checkBox_2);

        checkBox_3 = new QCheckBox(layoutWidget);
        checkBox_3->setObjectName(QString::fromUtf8("checkBox_3"));

        verticalLayout->addWidget(checkBox_3);

        checkBox_4 = new QCheckBox(layoutWidget);
        checkBox_4->setObjectName(QString::fromUtf8("checkBox_4"));

        verticalLayout->addWidget(checkBox_4);

        checkBox_5 = new QCheckBox(layoutWidget);
        checkBox_5->setObjectName(QString::fromUtf8("checkBox_5"));

        verticalLayout->addWidget(checkBox_5);

        lineEdit = new QLineEdit(layoutWidget);
        lineEdit->setObjectName(QString::fromUtf8("lineEdit"));

        verticalLayout->addWidget(lineEdit);

        label_3 = new QLabel(adddocket);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(269, 81, 16, 16));
        label_3->setFont(font1);
        lineEdit_caseNumber = new QLineEdit(adddocket);
        lineEdit_caseNumber->setObjectName(QString::fromUtf8("lineEdit_caseNumber"));
        lineEdit_caseNumber->setGeometry(QRect(137, 82, 125, 21));
        label = new QLabel(adddocket);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(57, 82, 72, 21));
        label->setFont(font);
        comboBox_session = new QComboBox(adddocket);
        comboBox_session->setObjectName(QString::fromUtf8("comboBox_session"));
        comboBox_session->setGeometry(QRect(167, 115, 104, 26));
        label_2 = new QLabel(adddocket);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(57, 117, 40, 21));
        label_2->setFont(font);
        label_4 = new QLabel(adddocket);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(56, 152, 59, 21));
        label_4->setFont(font);
        comboBox = new QComboBox(adddocket);
        comboBox->setObjectName(QString::fromUtf8("comboBox"));
        comboBox->setGeometry(QRect(152, 150, 124, 26));
        label_5 = new QLabel(adddocket);
        label_5->setObjectName(QString::fromUtf8("label_5"));
        label_5->setGeometry(QRect(56, 187, 64, 21));
        label_5->setFont(font);
        comboBox_2 = new QComboBox(adddocket);
        comboBox_2->setObjectName(QString::fromUtf8("comboBox_2"));
        comboBox_2->setGeometry(QRect(166, 185, 104, 26));

        retranslateUi(adddocket);
        QObject::connect(toolButton_docketAddCaseCancel, SIGNAL(clicked()), adddocket, SLOT(close()));
        QObject::connect(toolButton_docketAddCase, SIGNAL(clicked()), adddocket, SLOT(accept()));

        QMetaObject::connectSlotsByName(adddocket);
    } // setupUi

    void retranslateUi(QDialog *adddocket)
    {
        adddocket->setWindowTitle(QApplication::translate("adddocket", "Add Case To Docket", 0, QApplication::UnicodeUTF8));
        toolButton_docketAddCase->setText(QApplication::translate("adddocket", "ADD CASE", 0, QApplication::UnicodeUTF8));
        toolButton_docketAddCaseCancel->setText(QApplication::translate("adddocket", "CANCEL", 0, QApplication::UnicodeUTF8));
        label_docketAddCaseTitle->setText(QApplication::translate("adddocket", "Confirm:  Add Case to Court Docket", 0, QApplication::UnicodeUTF8));
        label_6->setText(QApplication::translate("adddocket", "Hearing Issues", 0, QApplication::UnicodeUTF8));
        checkBox->setText(QApplication::translate("adddocket", "Permanent RO", 0, QApplication::UnicodeUTF8));
        checkBox_2->setText(QApplication::translate("adddocket", "CC / CV", 0, QApplication::UnicodeUTF8));
        checkBox_3->setText(QApplication::translate("adddocket", "CS", 0, QApplication::UnicodeUTF8));
        checkBox_4->setText(QApplication::translate("adddocket", "SS", 0, QApplication::UnicodeUTF8));
        checkBox_5->setText(QApplication::translate("adddocket", "Other", 0, QApplication::UnicodeUTF8));
        label_3->setText(QString());
        lineEdit_caseNumber->setText(QApplication::translate("adddocket", "22-1251", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("adddocket", "Case Number", 0, QApplication::UnicodeUTF8));
        comboBox_session->clear();
        comboBox_session->insertItems(0, QStringList()
         << QApplication::translate("adddocket", "AM", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("adddocket", "PM", 0, QApplication::UnicodeUTF8)
        );
        label_2->setText(QApplication::translate("adddocket", "Session", 0, QApplication::UnicodeUTF8));
        label_4->setText(QApplication::translate("adddocket", "Courtroom", 0, QApplication::UnicodeUTF8));
        comboBox->clear();
        comboBox->insertItems(0, QStringList()
         << QApplication::translate("adddocket", "Courtroom A", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("adddocket", "Courtroom B", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("adddocket", "Courtroom C", 0, QApplication::UnicodeUTF8)
        );
        label_5->setText(QApplication::translate("adddocket", "Department", 0, QApplication::UnicodeUTF8));
        comboBox_2->clear();
        comboBox_2->insertItems(0, QStringList()
         << QApplication::translate("adddocket", "G1", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("adddocket", "G2", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("adddocket", "G3", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("adddocket", "New Item", 0, QApplication::UnicodeUTF8)
        );
    } // retranslateUi

};

namespace Ui {
    class adddocket: public Ui_adddocket {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_ADDDOCKET_H
