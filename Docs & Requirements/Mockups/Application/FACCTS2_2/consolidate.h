#ifndef CONSOLIDATE_H
#define CONSOLIDATE_H

#include <QDialog>

namespace Ui {
class Consolidate;
}

class Consolidate : public QDialog
{
    Q_OBJECT
    
public:
    explicit Consolidate(QWidget *parent = 0);
    ~Consolidate();
    
private:
    Ui::Consolidate *ui;
};

#endif // CONSOLIDATE_H
