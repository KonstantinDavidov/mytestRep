/********************************************************************************
** Form generated from reading UI file 'addparties.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_ADDPARTIES_H
#define UI_ADDPARTIES_H

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
#include <QtGui/QTreeWidget>

QT_BEGIN_NAMESPACE

class Ui_addparties
{
public:
    QToolButton *toolButton_Update;
    QToolButton *toolButton;
    QLineEdit *lineEdit_caseNumber;
    QTreeWidget *treeWidget_allParties;
    QLabel *label_caseNumber_2;
    QFrame *line;
    QToolButton *toolButton_add;
    QLabel *label_caseNumber_3;
    QLabel *label_caseNumber_4;
    QFrame *frame;
    QLabel *label_caseNumber_5;
    QComboBox *comboBox_2;
    QLabel *label_caseNumber_6;
    QLineEdit *lineEdit_3;
    QLineEdit *lineEdit_2;
    QLabel *label_caseNumber_8;
    QComboBox *comboBox;
    QLabel *label_caseNumber_7;
    QLabel *label_caseNumber_9;
    QLineEdit *lineEdit_4;
    QLabel *label_caseNumber_10;
    QToolButton *toolButton_add_2;
    QComboBox *comboBox_3;

    void setupUi(QDialog *addparties)
    {
        if (addparties->objectName().isEmpty())
            addparties->setObjectName(QString::fromUtf8("addparties"));
        addparties->resize(929, 402);
        QFont font;
        font.setPointSize(11);
        addparties->setFont(font);
        toolButton_Update = new QToolButton(addparties);
        toolButton_Update->setObjectName(QString::fromUtf8("toolButton_Update"));
        toolButton_Update->setGeometry(QRect(735, 350, 86, 23));
        toolButton = new QToolButton(addparties);
        toolButton->setObjectName(QString::fromUtf8("toolButton"));
        toolButton->setGeometry(QRect(825, 350, 86, 23));
        lineEdit_caseNumber = new QLineEdit(addparties);
        lineEdit_caseNumber->setObjectName(QString::fromUtf8("lineEdit_caseNumber"));
        lineEdit_caseNumber->setGeometry(QRect(35, 50, 113, 21));
        lineEdit_caseNumber->setFont(font);
        treeWidget_allParties = new QTreeWidget(addparties);
        QTreeWidgetItem *__qtreewidgetitem = new QTreeWidgetItem();
        __qtreewidgetitem->setText(0, QString::fromUtf8("1"));
        treeWidget_allParties->setHeaderItem(__qtreewidgetitem);
        treeWidget_allParties->setObjectName(QString::fromUtf8("treeWidget_allParties"));
        treeWidget_allParties->setGeometry(QRect(35, 100, 656, 176));
        treeWidget_allParties->setFont(font);
        treeWidget_allParties->setEditTriggers(QAbstractItemView::AllEditTriggers);
        treeWidget_allParties->setRootIsDecorated(false);
        label_caseNumber_2 = new QLabel(addparties);
        label_caseNumber_2->setObjectName(QString::fromUtf8("label_caseNumber_2"));
        label_caseNumber_2->setGeometry(QRect(35, 80, 271, 23));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_caseNumber_2->setFont(font1);
        line = new QFrame(addparties);
        line->setObjectName(QString::fromUtf8("line"));
        line->setGeometry(QRect(645, 340, 266, 10));
        line->setFrameShape(QFrame::HLine);
        line->setFrameShadow(QFrame::Sunken);
        toolButton_add = new QToolButton(addparties);
        toolButton_add->setObjectName(QString::fromUtf8("toolButton_add"));
        toolButton_add->setGeometry(QRect(605, 285, 86, 23));
        label_caseNumber_3 = new QLabel(addparties);
        label_caseNumber_3->setObjectName(QString::fromUtf8("label_caseNumber_3"));
        label_caseNumber_3->setGeometry(QRect(35, 25, 306, 23));
        label_caseNumber_3->setFont(font1);
        label_caseNumber_4 = new QLabel(addparties);
        label_caseNumber_4->setObjectName(QString::fromUtf8("label_caseNumber_4"));
        label_caseNumber_4->setGeometry(QRect(695, 80, 156, 23));
        label_caseNumber_4->setFont(font1);
        frame = new QFrame(addparties);
        frame->setObjectName(QString::fromUtf8("frame"));
        frame->setGeometry(QRect(695, 100, 216, 211));
        frame->setFrameShape(QFrame::StyledPanel);
        frame->setFrameShadow(QFrame::Raised);
        label_caseNumber_5 = new QLabel(frame);
        label_caseNumber_5->setObjectName(QString::fromUtf8("label_caseNumber_5"));
        label_caseNumber_5->setGeometry(QRect(10, 0, 81, 23));
        label_caseNumber_5->setFont(font);
        label_caseNumber_5->setAlignment(Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter);
        comboBox_2 = new QComboBox(frame);
        comboBox_2->setObjectName(QString::fromUtf8("comboBox_2"));
        comboBox_2->setGeometry(QRect(100, 75, 110, 23));
        label_caseNumber_6 = new QLabel(frame);
        label_caseNumber_6->setObjectName(QString::fromUtf8("label_caseNumber_6"));
        label_caseNumber_6->setGeometry(QRect(10, 25, 81, 23));
        label_caseNumber_6->setFont(font);
        label_caseNumber_6->setAlignment(Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter);
        lineEdit_3 = new QLineEdit(frame);
        lineEdit_3->setObjectName(QString::fromUtf8("lineEdit_3"));
        lineEdit_3->setGeometry(QRect(100, 25, 110, 21));
        lineEdit_2 = new QLineEdit(frame);
        lineEdit_2->setObjectName(QString::fromUtf8("lineEdit_2"));
        lineEdit_2->setGeometry(QRect(100, 50, 110, 21));
        label_caseNumber_8 = new QLabel(frame);
        label_caseNumber_8->setObjectName(QString::fromUtf8("label_caseNumber_8"));
        label_caseNumber_8->setGeometry(QRect(10, 75, 81, 23));
        label_caseNumber_8->setFont(font);
        label_caseNumber_8->setAlignment(Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter);
        comboBox = new QComboBox(frame);
        comboBox->setObjectName(QString::fromUtf8("comboBox"));
        comboBox->setGeometry(QRect(100, 0, 110, 23));
        label_caseNumber_7 = new QLabel(frame);
        label_caseNumber_7->setObjectName(QString::fromUtf8("label_caseNumber_7"));
        label_caseNumber_7->setGeometry(QRect(10, 50, 81, 23));
        label_caseNumber_7->setFont(font);
        label_caseNumber_7->setAlignment(Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter);
        label_caseNumber_9 = new QLabel(frame);
        label_caseNumber_9->setObjectName(QString::fromUtf8("label_caseNumber_9"));
        label_caseNumber_9->setGeometry(QRect(10, 100, 81, 23));
        label_caseNumber_9->setFont(font);
        label_caseNumber_9->setAlignment(Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter);
        lineEdit_4 = new QLineEdit(frame);
        lineEdit_4->setObjectName(QString::fromUtf8("lineEdit_4"));
        lineEdit_4->setGeometry(QRect(100, 125, 110, 21));
        label_caseNumber_10 = new QLabel(frame);
        label_caseNumber_10->setObjectName(QString::fromUtf8("label_caseNumber_10"));
        label_caseNumber_10->setGeometry(QRect(10, 125, 81, 23));
        label_caseNumber_10->setFont(font);
        label_caseNumber_10->setAlignment(Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter);
        toolButton_add_2 = new QToolButton(frame);
        toolButton_add_2->setObjectName(QString::fromUtf8("toolButton_add_2"));
        toolButton_add_2->setGeometry(QRect(125, 180, 86, 23));
        comboBox_3 = new QComboBox(frame);
        comboBox_3->setObjectName(QString::fromUtf8("comboBox_3"));
        comboBox_3->setGeometry(QRect(100, 100, 110, 23));

        retranslateUi(addparties);
        QObject::connect(toolButton, SIGNAL(clicked()), addparties, SLOT(close()));
        QObject::connect(toolButton_Update, SIGNAL(clicked()), addparties, SLOT(accept()));

        QMetaObject::connectSlotsByName(addparties);
    } // setupUi

    void retranslateUi(QDialog *addparties)
    {
        addparties->setWindowTitle(QApplication::translate("addparties", "Additional Parties Present", 0, QApplication::UnicodeUTF8));
        toolButton_Update->setText(QApplication::translate("addparties", "UPDATE", 0, QApplication::UnicodeUTF8));
        toolButton->setText(QApplication::translate("addparties", "CANCEL", 0, QApplication::UnicodeUTF8));
        lineEdit_caseNumber->setText(QApplication::translate("addparties", "22-1251", 0, QApplication::UnicodeUTF8));
        label_caseNumber_2->setText(QApplication::translate("addparties", "List Parties From Case Record", 0, QApplication::UnicodeUTF8));
        toolButton_add->setText(QApplication::translate("addparties", "PRESENT", 0, QApplication::UnicodeUTF8));
        label_caseNumber_3->setText(QApplication::translate("addparties", "Add parties present at the hearing for case number", 0, QApplication::UnicodeUTF8));
        label_caseNumber_4->setText(QApplication::translate("addparties", "New Party Present", 0, QApplication::UnicodeUTF8));
        label_caseNumber_5->setText(QApplication::translate("addparties", "ENTITY", 0, QApplication::UnicodeUTF8));
        comboBox_2->clear();
        comboBox_2->insertItems(0, QStringList()
         << QApplication::translate("addparties", "Witness", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addparties", "Child", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addparties", "Other Protected", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addparties", "Interpreter", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addparties", "Attorney", 0, QApplication::UnicodeUTF8)
        );
        label_caseNumber_6->setText(QApplication::translate("addparties", "First Name", 0, QApplication::UnicodeUTF8));
        label_caseNumber_8->setText(QApplication::translate("addparties", "Designation", 0, QApplication::UnicodeUTF8));
        comboBox->clear();
        comboBox->insertItems(0, QStringList()
         << QApplication::translate("addparties", "PERSON", 0, QApplication::UnicodeUTF8)
        );
        label_caseNumber_7->setText(QApplication::translate("addparties", "Last Name", 0, QApplication::UnicodeUTF8));
        label_caseNumber_9->setText(QApplication::translate("addparties", "Party For", 0, QApplication::UnicodeUTF8));
        label_caseNumber_10->setText(QApplication::translate("addparties", "Contact", 0, QApplication::UnicodeUTF8));
        toolButton_add_2->setText(QApplication::translate("addparties", "ADD", 0, QApplication::UnicodeUTF8));
        comboBox_3->clear();
        comboBox_3->insertItems(0, QStringList()
         << QApplication::translate("addparties", "Plaintiff", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addparties", "Respondent", 0, QApplication::UnicodeUTF8)
         << QApplication::translate("addparties", "Other", 0, QApplication::UnicodeUTF8)
        );
    } // retranslateUi

};

namespace Ui {
    class addparties: public Ui_addparties {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_ADDPARTIES_H
