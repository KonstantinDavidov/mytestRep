/********************************************************************************
** Form generated from reading UI file 'addrelatedcase.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_ADDRELATEDCASE_H
#define UI_ADDRELATEDCASE_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QComboBox>
#include <QtGui/QDialog>
#include <QtGui/QFrame>
#include <QtGui/QHBoxLayout>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QToolButton>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_addrelatedcase
{
public:
    QToolButton *toolButton;
    QToolButton *toolButton_2;
    QFrame *line;
    QLabel *label;
    QLabel *label_caseNumber;
    QLabel *label_caseType;
    QFrame *line_2;
    QLabel *label_caseNumber_2;
    QFrame *frame_warnSaveCase;
    QWidget *widget;
    QHBoxLayout *horizontalLayout;
    QLineEdit *lineEdit;
    QComboBox *comboBox;

    void setupUi(QDialog *addrelatedcase)
    {
        if (addrelatedcase->objectName().isEmpty())
            addrelatedcase->setObjectName(QString::fromUtf8("addrelatedcase"));
        addrelatedcase->resize(400, 208);
        QFont font;
        font.setPointSize(11);
        addrelatedcase->setFont(font);
        toolButton = new QToolButton(addrelatedcase);
        toolButton->setObjectName(QString::fromUtf8("toolButton"));
        toolButton->setGeometry(QRect(310, 160, 71, 23));
        toolButton_2 = new QToolButton(addrelatedcase);
        toolButton_2->setObjectName(QString::fromUtf8("toolButton_2"));
        toolButton_2->setGeometry(QRect(235, 160, 71, 23));
        line = new QFrame(addrelatedcase);
        line->setObjectName(QString::fromUtf8("line"));
        line->setGeometry(QRect(202, 150, 181, 10));
        line->setFrameShape(QFrame::HLine);
        line->setFrameShadow(QFrame::Sunken);
        label = new QLabel(addrelatedcase);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(115, 80, 261, 26));
        label->setFont(font);
        label->setWordWrap(true);
        label_caseNumber = new QLabel(addrelatedcase);
        label_caseNumber->setObjectName(QString::fromUtf8("label_caseNumber"));
        label_caseNumber->setGeometry(QRect(80, 110, 96, 16));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_caseNumber->setFont(font1);
        label_caseType = new QLabel(addrelatedcase);
        label_caseType->setObjectName(QString::fromUtf8("label_caseType"));
        label_caseType->setGeometry(QRect(215, 110, 62, 16));
        label_caseType->setFont(font1);
        line_2 = new QFrame(addrelatedcase);
        line_2->setObjectName(QString::fromUtf8("line_2"));
        line_2->setGeometry(QRect(85, 70, 306, 16));
        line_2->setFrameShape(QFrame::HLine);
        line_2->setFrameShadow(QFrame::Sunken);
        label_caseNumber_2 = new QLabel(addrelatedcase);
        label_caseNumber_2->setObjectName(QString::fromUtf8("label_caseNumber_2"));
        label_caseNumber_2->setGeometry(QRect(85, 60, 296, 16));
        label_caseNumber_2->setFont(font1);
        frame_warnSaveCase = new QFrame(addrelatedcase);
        frame_warnSaveCase->setObjectName(QString::fromUtf8("frame_warnSaveCase"));
        frame_warnSaveCase->setGeometry(QRect(30, 50, 53, 53));
        frame_warnSaveCase->setStyleSheet(QString::fromUtf8("background-image: url(:/new/prefix1/_images/warning_1.png);"));
        frame_warnSaveCase->setFrameShape(QFrame::NoFrame);
        frame_warnSaveCase->setFrameShadow(QFrame::Raised);
        widget = new QWidget(addrelatedcase);
        widget->setObjectName(QString::fromUtf8("widget"));
        widget->setGeometry(QRect(80, 125, 246, 27));
        horizontalLayout = new QHBoxLayout(widget);
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        horizontalLayout->setContentsMargins(0, 0, 0, 0);
        lineEdit = new QLineEdit(widget);
        lineEdit->setObjectName(QString::fromUtf8("lineEdit"));

        horizontalLayout->addWidget(lineEdit);

        comboBox = new QComboBox(widget);
        comboBox->setObjectName(QString::fromUtf8("comboBox"));

        horizontalLayout->addWidget(comboBox);


        retranslateUi(addrelatedcase);
        QObject::connect(toolButton, SIGNAL(clicked()), addrelatedcase, SLOT(close()));
        QObject::connect(toolButton_2, SIGNAL(clicked()), addrelatedcase, SLOT(accept()));

        QMetaObject::connectSlotsByName(addrelatedcase);
    } // setupUi

    void retranslateUi(QDialog *addrelatedcase)
    {
        addrelatedcase->setWindowTitle(QApplication::translate("addrelatedcase", "ADD OUTSIDE FACCTS CASE", 0, QApplication::UnicodeUTF8));
        toolButton->setText(QApplication::translate("addrelatedcase", "CANCEL", 0, QApplication::UnicodeUTF8));
        toolButton_2->setText(QApplication::translate("addrelatedcase", "ADD CASE", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("addrelatedcase", "Add a case which is outside the FACCTS application to this master case", 0, QApplication::UnicodeUTF8));
        label_caseNumber->setText(QApplication::translate("addrelatedcase", "Case Number", 0, QApplication::UnicodeUTF8));
        label_caseType->setText(QApplication::translate("addrelatedcase", "Case Type", 0, QApplication::UnicodeUTF8));
        label_caseNumber_2->setText(QApplication::translate("addrelatedcase", "CONFIRM: ADD OUTSIDE CASE TO RELATED CASES", 0, QApplication::UnicodeUTF8));
        comboBox->clear();
        comboBox->insertItems(0, QStringList()
         << QApplication::translate("addrelatedcase", "CPO", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addrelatedcase", "TRO", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addrelatedcase", "Dissolution", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addrelatedcase", "Criminal", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addrelatedcase", "Civil", 0, QApplication::UnicodeUTF8)
        );
    } // retranslateUi

};

namespace Ui {
    class addrelatedcase: public Ui_addrelatedcase {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_ADDRELATEDCASE_H
