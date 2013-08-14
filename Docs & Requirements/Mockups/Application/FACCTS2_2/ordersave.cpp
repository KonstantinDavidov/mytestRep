#include "ordersave.h"
#include "ui_ordersave.h"

ordersave::ordersave(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::ordersave)
{
    ui->setupUi(this);


}


void ordersave::setOrderId(QString orderId)
{
    ui->lineEdit_orderId->setText(orderId);
}



ordersave::~ordersave()
{
    delete ui;
}
