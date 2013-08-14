#ifndef ORDERSAVE_H
#define ORDERSAVE_H

#include <QDialog>

namespace Ui {
class ordersave;
}

class ordersave : public QDialog
{
    Q_OBJECT
    
public:
    explicit ordersave(QWidget *parent = 0);
    ~ordersave();


void setOrderId(QString orderId);

private:
    Ui::ordersave *ui;
};

#endif // ORDERSAVE_H
