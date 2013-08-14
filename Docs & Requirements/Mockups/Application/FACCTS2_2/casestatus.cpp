#include "casestatus.h"
#include "ui_casestatus.h"

casestatus::casestatus(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::casestatus)
{
    ui->setupUi(this);
}

casestatus::~casestatus()
{
    delete ui;
}
