#ifndef GENERATEORDERS_H
#define GENERATEORDERS_H

#include <QDialog>
#include <QDirModel>
#include <QtGui>
#include <QtCore>

namespace Ui {
class generateOrders;
}

class generateOrders : public QDialog
{
    Q_OBJECT

//LOAD CASE DOCUMENT STACK
void LoadDocStack();



public:
    explicit generateOrders(QWidget *parent = 0);
    ~generateOrders();

//LOAD CASE ID
void SetOrderID(QString orderId);


private:
    Ui::generateOrders *ui;
};

#endif // GENERATEORDERS_H
