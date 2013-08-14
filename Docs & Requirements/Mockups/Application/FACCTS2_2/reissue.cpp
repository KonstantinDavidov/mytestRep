#include "reissue.h"
#include "ui_reissue.h"

Reissue::Reissue(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Reissue)
{
    ui->setupUi(this);
}

Reissue::~Reissue()
{
    delete ui;
}
