/********************************************************************************
** Form generated from reading UI file 'consolidate.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CONSOLIDATE_H
#define UI_CONSOLIDATE_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QDialog>
#include <QtGui/QFrame>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QListWidget>
#include <QtGui/QToolButton>

QT_BEGIN_NAMESPACE

class Ui_Consolidate
{
public:
    QToolButton *toolButton_consolidateCancel;
    QToolButton *toolButton_consolidateMerge;
    QFrame *line_mainConsolidate;
    QLabel *label_caseMerge;
    QFrame *line_consolidate4;
    QLineEdit *lineEdit_caseConsolidateMaster;
    QLabel *label_caseMaster;
    QLabel *label_caseMergeTitle;
    QFrame *line_consolidate2;
    QFrame *line_consolidate1;
    QFrame *line_consolidate3;
    QFrame *line_lowerConsolidate;
    QListWidget *listWidget;

    void setupUi(QDialog *Consolidate)
    {
        if (Consolidate->objectName().isEmpty())
            Consolidate->setObjectName(QString::fromUtf8("Consolidate"));
        Consolidate->resize(400, 269);
        QFont font;
        font.setPointSize(11);
        Consolidate->setFont(font);
        toolButton_consolidateCancel = new QToolButton(Consolidate);
        toolButton_consolidateCancel->setObjectName(QString::fromUtf8("toolButton_consolidateCancel"));
        toolButton_consolidateCancel->setGeometry(QRect(308, 225, 71, 23));
        toolButton_consolidateMerge = new QToolButton(Consolidate);
        toolButton_consolidateMerge->setObjectName(QString::fromUtf8("toolButton_consolidateMerge"));
        toolButton_consolidateMerge->setGeometry(QRect(230, 225, 71, 23));
        line_mainConsolidate = new QFrame(Consolidate);
        line_mainConsolidate->setObjectName(QString::fromUtf8("line_mainConsolidate"));
        line_mainConsolidate->setGeometry(QRect(25, 60, 346, 16));
        line_mainConsolidate->setFrameShape(QFrame::HLine);
        line_mainConsolidate->setFrameShadow(QFrame::Sunken);
        label_caseMerge = new QLabel(Consolidate);
        label_caseMerge->setObjectName(QString::fromUtf8("label_caseMerge"));
        label_caseMerge->setGeometry(QRect(25, 195, 121, 23));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(false);
        font1.setWeight(50);
        label_caseMerge->setFont(font1);
        label_caseMerge->setAlignment(Qt::AlignCenter);
        line_consolidate4 = new QFrame(Consolidate);
        line_consolidate4->setObjectName(QString::fromUtf8("line_consolidate4"));
        line_consolidate4->setGeometry(QRect(183, 90, 26, 101));
        line_consolidate4->setFrameShadow(QFrame::Plain);
        line_consolidate4->setFrameShape(QFrame::VLine);
        lineEdit_caseConsolidateMaster = new QLineEdit(Consolidate);
        lineEdit_caseConsolidateMaster->setObjectName(QString::fromUtf8("lineEdit_caseConsolidateMaster"));
        lineEdit_caseConsolidateMaster->setGeometry(QRect(245, 130, 113, 22));
        label_caseMaster = new QLabel(Consolidate);
        label_caseMaster->setObjectName(QString::fromUtf8("label_caseMaster"));
        label_caseMaster->setGeometry(QRect(245, 150, 111, 23));
        label_caseMaster->setFont(font1);
        label_caseMaster->setAlignment(Qt::AlignCenter);
        label_caseMergeTitle = new QLabel(Consolidate);
        label_caseMergeTitle->setObjectName(QString::fromUtf8("label_caseMergeTitle"));
        label_caseMergeTitle->setGeometry(QRect(25, 45, 226, 23));
        QFont font2;
        font2.setPointSize(11);
        font2.setBold(true);
        font2.setWeight(75);
        label_caseMergeTitle->setFont(font2);
        label_caseMergeTitle->setAlignment(Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter);
        line_consolidate2 = new QFrame(Consolidate);
        line_consolidate2->setObjectName(QString::fromUtf8("line_consolidate2"));
        line_consolidate2->setGeometry(QRect(197, 130, 46, 20));
        line_consolidate2->setFrameShadow(QFrame::Plain);
        line_consolidate2->setFrameShape(QFrame::HLine);
        line_consolidate1 = new QFrame(Consolidate);
        line_consolidate1->setObjectName(QString::fromUtf8("line_consolidate1"));
        line_consolidate1->setGeometry(QRect(150, 80, 46, 20));
        line_consolidate1->setFrameShadow(QFrame::Plain);
        line_consolidate1->setFrameShape(QFrame::HLine);
        line_consolidate3 = new QFrame(Consolidate);
        line_consolidate3->setObjectName(QString::fromUtf8("line_consolidate3"));
        line_consolidate3->setGeometry(QRect(150, 180, 46, 20));
        line_consolidate3->setFrameShadow(QFrame::Plain);
        line_consolidate3->setFrameShape(QFrame::HLine);
        line_lowerConsolidate = new QFrame(Consolidate);
        line_lowerConsolidate->setObjectName(QString::fromUtf8("line_lowerConsolidate"));
        line_lowerConsolidate->setGeometry(QRect(160, 210, 221, 16));
        line_lowerConsolidate->setFrameShape(QFrame::HLine);
        line_lowerConsolidate->setFrameShadow(QFrame::Sunken);
        listWidget = new QListWidget(Consolidate);
        new QListWidgetItem(listWidget);
        listWidget->setObjectName(QString::fromUtf8("listWidget"));
        listWidget->setGeometry(QRect(25, 85, 121, 111));
        listWidget->setFont(font2);

        retranslateUi(Consolidate);
        QObject::connect(toolButton_consolidateCancel, SIGNAL(clicked()), Consolidate, SLOT(close()));
        QObject::connect(toolButton_consolidateMerge, SIGNAL(clicked()), Consolidate, SLOT(accept()));

        QMetaObject::connectSlotsByName(Consolidate);
    } // setupUi

    void retranslateUi(QDialog *Consolidate)
    {
        Consolidate->setWindowTitle(QApplication::translate("Consolidate", "Case Consolidation", 0, QApplication::UnicodeUTF8));
        toolButton_consolidateCancel->setText(QApplication::translate("Consolidate", "CANCEL", 0, QApplication::UnicodeUTF8));
        toolButton_consolidateMerge->setText(QApplication::translate("Consolidate", "MERGE", 0, QApplication::UnicodeUTF8));
        label_caseMerge->setText(QApplication::translate("Consolidate", "Cases to Merge", 0, QApplication::UnicodeUTF8));
        label_caseMaster->setText(QApplication::translate("Consolidate", "Master Case", 0, QApplication::UnicodeUTF8));
        label_caseMergeTitle->setText(QApplication::translate("Consolidate", "CONFIRM: CASE CONSOLIDATION", 0, QApplication::UnicodeUTF8));

        const bool __sortingEnabled = listWidget->isSortingEnabled();
        listWidget->setSortingEnabled(false);
        QListWidgetItem *___qlistwidgetitem = listWidget->item(0);
        ___qlistwidgetitem->setText(QApplication::translate("Consolidate", "22-1111", 0, QApplication::UnicodeUTF8));
        listWidget->setSortingEnabled(__sortingEnabled);

    } // retranslateUi

};

namespace Ui {
    class Consolidate: public Ui_Consolidate {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CONSOLIDATE_H
