#ifndef RENEWCASE_H
#define RENEWCASE_H

#include <QDialog>

namespace Ui {
class renewCase;
}

class renewCase : public QDialog
{
    Q_OBJECT
    
public:
    explicit renewCase(QWidget *parent = 0);
    ~renewCase();
    
private:
    Ui::renewCase *ui;
};

#endif // RENEWCASE_H
