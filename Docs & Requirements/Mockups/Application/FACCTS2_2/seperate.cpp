#include "seperate.h"
#include "ui_seperate.h"

seperate::seperate(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::seperate)
{
    ui->setupUi(this);
}

seperate::~seperate()
{
    delete ui;
}
