#ifndef NEWCASE_H
#define NEWCASE_H

#include "mainwindow.h"
#include <QDialog>
#include <QtCore>

namespace Ui {
class newCase;
}

class newCase : public QDialog
{
    Q_OBJECT

    
public:
    explicit newCase(QWidget *parent = 0);
    ~newCase();




private slots:
    void on_toolButton_newCaseCreate_clicked();

private:
    Ui::newCase *ui;
};

#endif // NEWCASE_H
