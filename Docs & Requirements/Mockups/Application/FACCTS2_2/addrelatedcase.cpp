#include "addrelatedcase.h"
#include "ui_addrelatedcase.h"

addrelatedcase::addrelatedcase(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::addrelatedcase)
{
    ui->setupUi(this);
}

addrelatedcase::~addrelatedcase()
{
    delete ui;
}
