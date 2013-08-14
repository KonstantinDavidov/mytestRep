#include "continuance.h"
#include "ui_continuance.h"

Continuance::Continuance(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Continuance)
{
    ui->setupUi(this);
}

Continuance::~Continuance()
{
    delete ui;
}
