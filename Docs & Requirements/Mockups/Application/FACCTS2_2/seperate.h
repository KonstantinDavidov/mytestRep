#ifndef SEPERATE_H
#define SEPERATE_H

#include <QDialog>

namespace Ui {
class seperate;
}

class seperate : public QDialog
{
    Q_OBJECT
    
public:
    explicit seperate(QWidget *parent = 0);
    ~seperate();
    
private:
    Ui::seperate *ui;
};

#endif // SEPERATE_H
