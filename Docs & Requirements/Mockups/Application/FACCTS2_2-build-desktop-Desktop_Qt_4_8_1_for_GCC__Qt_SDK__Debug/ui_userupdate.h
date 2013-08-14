/********************************************************************************
** Form generated from reading UI file 'userupdate.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_USERUPDATE_H
#define UI_USERUPDATE_H

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

class Ui_userupdate
{
public:
    QToolButton *toolButton_addUser;
    QToolButton *toolButton_addUserCancel;
    QFrame *line_loweraddUser;
    QFrame *line_mainAddUser;
    QLabel *label_addUserTitle;
    QLineEdit *lineEdit_firstNameAdd;
    QLineEdit *lineEdit_middleNameAdd;
    QLineEdit *lineEdit_lastNameAdd;
    QLineEdit *lineEdit_eMailAdd;
    QLabel *label_firstNameAddUser;
    QLabel *label_middleNameAddUser;
    QLabel *label_lastNameAddUser;
    QLabel *label_eMailAddUser;
    QLabel *label_addUserInstruction;

    void setupUi(QDialog *userupdate)
    {
        if (userupdate->objectName().isEmpty())
            userupdate->setObjectName(QString::fromUtf8("userupdate"));
        userupdate->resize(386, 271);
        toolButton_addUser = new QToolButton(userupdate);
        toolButton_addUser->setObjectName(QString::fromUtf8("toolButton_addUser"));
        toolButton_addUser->setGeometry(QRect(185, 230, 85, 23));
        toolButton_addUserCancel = new QToolButton(userupdate);
        toolButton_addUserCancel->setObjectName(QString::fromUtf8("toolButton_addUserCancel"));
        toolButton_addUserCancel->setGeometry(QRect(275, 230, 85, 23));
        line_loweraddUser = new QFrame(userupdate);
        line_loweraddUser->setObjectName(QString::fromUtf8("line_loweraddUser"));
        line_loweraddUser->setGeometry(QRect(155, 215, 206, 21));
        line_loweraddUser->setFrameShape(QFrame::HLine);
        line_loweraddUser->setFrameShadow(QFrame::Sunken);
        line_mainAddUser = new QFrame(userupdate);
        line_mainAddUser->setObjectName(QString::fromUtf8("line_mainAddUser"));
        line_mainAddUser->setGeometry(QRect(40, 60, 291, 21));
        line_mainAddUser->setFrameShape(QFrame::HLine);
        line_mainAddUser->setFrameShadow(QFrame::Sunken);
        label_addUserTitle = new QLabel(userupdate);
        label_addUserTitle->setObjectName(QString::fromUtf8("label_addUserTitle"));
        label_addUserTitle->setGeometry(QRect(40, 50, 206, 21));
        QFont font;
        font.setPointSize(11);
        font.setBold(true);
        font.setWeight(75);
        label_addUserTitle->setFont(font);
        lineEdit_firstNameAdd = new QLineEdit(userupdate);
        lineEdit_firstNameAdd->setObjectName(QString::fromUtf8("lineEdit_firstNameAdd"));
        lineEdit_firstNameAdd->setGeometry(QRect(205, 80, 126, 22));
        QFont font1;
        font1.setPointSize(11);
        lineEdit_firstNameAdd->setFont(font1);
        lineEdit_middleNameAdd = new QLineEdit(userupdate);
        lineEdit_middleNameAdd->setObjectName(QString::fromUtf8("lineEdit_middleNameAdd"));
        lineEdit_middleNameAdd->setGeometry(QRect(205, 105, 126, 22));
        lineEdit_middleNameAdd->setFont(font1);
        lineEdit_lastNameAdd = new QLineEdit(userupdate);
        lineEdit_lastNameAdd->setObjectName(QString::fromUtf8("lineEdit_lastNameAdd"));
        lineEdit_lastNameAdd->setGeometry(QRect(205, 130, 126, 22));
        lineEdit_lastNameAdd->setFont(font1);
        lineEdit_eMailAdd = new QLineEdit(userupdate);
        lineEdit_eMailAdd->setObjectName(QString::fromUtf8("lineEdit_eMailAdd"));
        lineEdit_eMailAdd->setGeometry(QRect(205, 170, 126, 22));
        lineEdit_eMailAdd->setFont(font1);
        label_firstNameAddUser = new QLabel(userupdate);
        label_firstNameAddUser->setObjectName(QString::fromUtf8("label_firstNameAddUser"));
        label_firstNameAddUser->setGeometry(QRect(75, 80, 121, 23));
        label_firstNameAddUser->setFont(font1);
        label_firstNameAddUser->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        label_middleNameAddUser = new QLabel(userupdate);
        label_middleNameAddUser->setObjectName(QString::fromUtf8("label_middleNameAddUser"));
        label_middleNameAddUser->setGeometry(QRect(70, 105, 126, 23));
        label_middleNameAddUser->setFont(font1);
        label_middleNameAddUser->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        label_lastNameAddUser = new QLabel(userupdate);
        label_lastNameAddUser->setObjectName(QString::fromUtf8("label_lastNameAddUser"));
        label_lastNameAddUser->setGeometry(QRect(65, 130, 131, 23));
        label_lastNameAddUser->setFont(font1);
        label_lastNameAddUser->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        label_eMailAddUser = new QLabel(userupdate);
        label_eMailAddUser->setObjectName(QString::fromUtf8("label_eMailAddUser"));
        label_eMailAddUser->setGeometry(QRect(70, 170, 126, 23));
        label_eMailAddUser->setFont(font1);
        label_eMailAddUser->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        label_addUserInstruction = new QLabel(userupdate);
        label_addUserInstruction->setObjectName(QString::fromUtf8("label_addUserInstruction"));
        label_addUserInstruction->setGeometry(QRect(205, 190, 126, 23));
        label_addUserInstruction->setFont(font1);
        label_addUserInstruction->setStyleSheet(QString::fromUtf8("color: rgb(255, 0, 19);"));
        label_addUserInstruction->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        retranslateUi(userupdate);
        QObject::connect(toolButton_addUserCancel, SIGNAL(clicked()), userupdate, SLOT(close()));
        QObject::connect(toolButton_addUser, SIGNAL(clicked()), userupdate, SLOT(accept()));

        QMetaObject::connectSlotsByName(userupdate);
    } // setupUi

    void retranslateUi(QDialog *userupdate)
    {
        userupdate->setWindowTitle(QApplication::translate("userupdate", "Add New User", 0, QApplication::UnicodeUTF8));
        toolButton_addUser->setText(QApplication::translate("userupdate", "ADD USER", 0, QApplication::UnicodeUTF8));
        toolButton_addUserCancel->setText(QApplication::translate("userupdate", "CANCEL", 0, QApplication::UnicodeUTF8));
        label_addUserTitle->setText(QApplication::translate("userupdate", "ADD NEW FACCTS2 USER", 0, QApplication::UnicodeUTF8));
        label_firstNameAddUser->setText(QApplication::translate("userupdate", "User - First Name*", 0, QApplication::UnicodeUTF8));
        label_middleNameAddUser->setText(QApplication::translate("userupdate", "User - Middle Name ", 0, QApplication::UnicodeUTF8));
        label_lastNameAddUser->setText(QApplication::translate("userupdate", "User - Last Name*", 0, QApplication::UnicodeUTF8));
        label_eMailAddUser->setText(QApplication::translate("userupdate", "User - Email Address*", 0, QApplication::UnicodeUTF8));
        label_addUserInstruction->setText(QApplication::translate("userupdate", "* Required", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class userupdate: public Ui_userupdate {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_USERUPDATE_H
