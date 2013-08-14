/********************************************************************************
** Form generated from reading UI file 'ordersave.ui'
**
** Created: Tue Aug 13 13:48:30 2013
**      by: Qt User Interface Compiler version 4.8.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_ORDERSAVE_H
#define UI_ORDERSAVE_H

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
#include <QtGui/QListWidget>
#include <QtGui/QToolButton>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_ordersave
{
public:
    QToolButton *toolButton_saveOrders;
    QToolButton *toolButton_cancelOrders;
    QFrame *line_mainSaveOrder;
    QLabel *label_saveOrder;
    QFrame *frame_warnSaveOrders;
    QLabel *label_saveOrderInstruction;
    QFrame *line_lowerSaveOrder;
    QListWidget *listWidget;
    QLabel *label_2;
    QWidget *layoutWidget;
    QHBoxLayout *horizontalLayout;
    QLabel *label;
    QLineEdit *lineEdit_orderId;
    QLabel *label_data;
    QLabel *label_data_2;

    void setupUi(QDialog *ordersave)
    {
        if (ordersave->objectName().isEmpty())
            ordersave->setObjectName(QString::fromUtf8("ordersave"));
        ordersave->resize(400, 247);
        QFont font;
        font.setPointSize(11);
        ordersave->setFont(font);
        toolButton_saveOrders = new QToolButton(ordersave);
        toolButton_saveOrders->setObjectName(QString::fromUtf8("toolButton_saveOrders"));
        toolButton_saveOrders->setGeometry(QRect(210, 205, 85, 23));
        toolButton_cancelOrders = new QToolButton(ordersave);
        toolButton_cancelOrders->setObjectName(QString::fromUtf8("toolButton_cancelOrders"));
        toolButton_cancelOrders->setGeometry(QRect(300, 205, 85, 23));
        line_mainSaveOrder = new QFrame(ordersave);
        line_mainSaveOrder->setObjectName(QString::fromUtf8("line_mainSaveOrder"));
        line_mainSaveOrder->setGeometry(QRect(85, 60, 286, 16));
        line_mainSaveOrder->setFrameShape(QFrame::HLine);
        line_mainSaveOrder->setFrameShadow(QFrame::Sunken);
        label_saveOrder = new QLabel(ordersave);
        label_saveOrder->setObjectName(QString::fromUtf8("label_saveOrder"));
        label_saveOrder->setGeometry(QRect(85, 50, 250, 16));
        QFont font1;
        font1.setPointSize(11);
        font1.setBold(true);
        font1.setWeight(75);
        label_saveOrder->setFont(font1);
        frame_warnSaveOrders = new QFrame(ordersave);
        frame_warnSaveOrders->setObjectName(QString::fromUtf8("frame_warnSaveOrders"));
        frame_warnSaveOrders->setGeometry(QRect(30, 35, 53, 53));
        frame_warnSaveOrders->setStyleSheet(QString::fromUtf8("background-image: url(:/new/prefix1/_images/warning_1.png);"));
        frame_warnSaveOrders->setFrameShape(QFrame::NoFrame);
        frame_warnSaveOrders->setFrameShadow(QFrame::Raised);
        label_saveOrderInstruction = new QLabel(ordersave);
        label_saveOrderInstruction->setObjectName(QString::fromUtf8("label_saveOrderInstruction"));
        label_saveOrderInstruction->setGeometry(QRect(100, 70, 256, 31));
        label_saveOrderInstruction->setFont(font);
        label_saveOrderInstruction->setWordWrap(true);
        line_lowerSaveOrder = new QFrame(ordersave);
        line_lowerSaveOrder->setObjectName(QString::fromUtf8("line_lowerSaveOrder"));
        line_lowerSaveOrder->setGeometry(QRect(175, 190, 216, 21));
        line_lowerSaveOrder->setFrameShape(QFrame::HLine);
        line_lowerSaveOrder->setFrameShadow(QFrame::Sunken);
        listWidget = new QListWidget(ordersave);
        new QListWidgetItem(listWidget);
        listWidget->setObjectName(QString::fromUtf8("listWidget"));
        listWidget->setGeometry(QRect(225, 135, 131, 56));
        listWidget->setFont(font1);
        listWidget->setEditTriggers(QAbstractItemView::NoEditTriggers);
        label_2 = new QLabel(ordersave);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(140, 130, 96, 26));
        label_2->setFont(font1);
        layoutWidget = new QWidget(ordersave);
        layoutWidget->setObjectName(QString::fromUtf8("layoutWidget"));
        layoutWidget->setGeometry(QRect(140, 105, 216, 23));
        horizontalLayout = new QHBoxLayout(layoutWidget);
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        horizontalLayout->setContentsMargins(0, 0, 0, 0);
        label = new QLabel(layoutWidget);
        label->setObjectName(QString::fromUtf8("label"));
        label->setFont(font1);

        horizontalLayout->addWidget(label);

        lineEdit_orderId = new QLineEdit(layoutWidget);
        lineEdit_orderId->setObjectName(QString::fromUtf8("lineEdit_orderId"));
        lineEdit_orderId->setReadOnly(true);

        horizontalLayout->addWidget(lineEdit_orderId);

        label_data = new QLabel(ordersave);
        label_data->setObjectName(QString::fromUtf8("label_data"));
        label_data->setGeometry(QRect(30, 160, 62, 16));
        label_data_2 = new QLabel(ordersave);
        label_data_2->setObjectName(QString::fromUtf8("label_data_2"));
        label_data_2->setGeometry(QRect(30, 155, 62, 16));

        retranslateUi(ordersave);
        QObject::connect(toolButton_cancelOrders, SIGNAL(clicked()), ordersave, SLOT(close()));
        QObject::connect(toolButton_saveOrders, SIGNAL(clicked()), ordersave, SLOT(accept()));

        QMetaObject::connectSlotsByName(ordersave);
    } // setupUi

    void retranslateUi(QDialog *ordersave)
    {
        ordersave->setWindowTitle(QApplication::translate("ordersave", "Save Court Orders", 0, QApplication::UnicodeUTF8));
        toolButton_saveOrders->setText(QApplication::translate("ordersave", "SAVE", 0, QApplication::UnicodeUTF8));
        toolButton_cancelOrders->setText(QApplication::translate("ordersave", "CANCEL", 0, QApplication::UnicodeUTF8));
        label_saveOrder->setText(QApplication::translate("ordersave", "Confirmation: Save Court Orders", 0, QApplication::UnicodeUTF8));
        label_saveOrderInstruction->setText(QApplication::translate("ordersave", "You are about to save court orders.   Are you sure ?", 0, QApplication::UnicodeUTF8));

        const bool __sortingEnabled = listWidget->isSortingEnabled();
        listWidget->setSortingEnabled(false);
        QListWidgetItem *___qlistwidgetitem = listWidget->item(0);
        ___qlistwidgetitem->setText(QApplication::translate("ordersave", "DV110", 0, QApplication::UnicodeUTF8));
        listWidget->setSortingEnabled(__sortingEnabled);

        label_2->setText(QApplication::translate("ordersave", "Master Orders", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("ordersave", "Case Number", 0, QApplication::UnicodeUTF8));
        lineEdit_orderId->setText(QString());
        label_data->setText(QString());
        label_data_2->setText(QString());
    } // retranslateUi

};

namespace Ui {
    class ordersave: public Ui_ordersave {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_ORDERSAVE_H
