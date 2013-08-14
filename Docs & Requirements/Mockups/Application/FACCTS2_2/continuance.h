#ifndef CONTINUANCE_H
#define CONTINUANCE_H

#include <QDialog>

namespace Ui {
class Continuance;
}

class Continuance : public QDialog
{
    Q_OBJECT
    
public:
    explicit Continuance(QWidget *parent = 0);
    ~Continuance();
    
private:
    Ui::Continuance *ui;
};

#endif // CONTINUANCE_H
