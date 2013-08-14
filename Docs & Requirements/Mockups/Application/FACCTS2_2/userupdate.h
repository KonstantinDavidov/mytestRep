#ifndef USERUPDATE_H
#define USERUPDATE_H

#include <QDialog>

namespace Ui {
class userupdate;
}

class userupdate : public QDialog
{
    Q_OBJECT

void AddUser();


public:
    explicit userupdate(QWidget *parent = 0);
    ~userupdate();
    
private slots:
    void on_toolButton_addUser_clicked();

private:
    Ui::userupdate *ui;
};

#endif // USERUPDATE_H
