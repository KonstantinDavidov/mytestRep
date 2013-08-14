#include "renewcase.h"
#include "ui_renewcase.h"

renewCase::renewCase(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::renewCase)
{
    ui->setupUi(this);
}

renewCase::~renewCase()
{
    delete ui;
}
