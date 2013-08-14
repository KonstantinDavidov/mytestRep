#ifndef ADDDOCKET_H
#define ADDDOCKET_H

#include <QDialog>

namespace Ui {
class adddocket;
}

class adddocket : public QDialog
{
    Q_OBJECT
    
public:
    explicit adddocket(QWidget *parent = 0);
    ~adddocket();

void setCaseAdd(QString caseId);
    
private:
    Ui::adddocket *ui;
};

#endif // ADDDOCKET_H
