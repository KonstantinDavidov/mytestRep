#ifndef REMOVEDOCKET_H
#define REMOVEDOCKET_H

#include <QDialog>

namespace Ui {
class removedocket;
}

class removedocket : public QDialog
{
    Q_OBJECT





public:
    explicit removedocket(QWidget *parent = 0);
    ~removedocket();

void setData(QString caseNumber);

private:
    Ui::removedocket *ui;
};

#endif // REMOVEDOCKET_H
