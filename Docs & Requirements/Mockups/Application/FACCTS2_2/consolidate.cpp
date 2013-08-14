#include "consolidate.h"
#include "ui_consolidate.h"

Consolidate::Consolidate(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Consolidate)
{
    ui->setupUi(this);
}

Consolidate::~Consolidate()
{
    delete ui;
}
