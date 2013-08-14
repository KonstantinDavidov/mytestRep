#include "removedocket.h"
#include "ui_removedocket.h"

removedocket::removedocket(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::removedocket)
{
    ui->setupUi(this);
}

void removedocket::setData(QString caseNumber)
{
    ui->lineEdit_caseNumber->setText(caseNumber);
}



removedocket::~removedocket()
{
    delete ui;
}
