#include "adddocket.h"
#include "ui_adddocket.h"

adddocket::adddocket(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::adddocket)
{

    ui->setupUi(this);
}


void adddocket::setCaseAdd(QString caseId)
{
    ui->lineEdit_caseNumber->setText(caseId);
}



adddocket::~adddocket()
{
    delete ui;
}
