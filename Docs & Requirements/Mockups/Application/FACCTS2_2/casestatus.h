#ifndef CASESTATUS_H
#define CASESTATUS_H

#include <QDialog>

namespace Ui {
class casestatus;
}

class casestatus : public QDialog
{
    Q_OBJECT
    
public:
    explicit casestatus(QWidget *parent = 0);
    ~casestatus();
    
private:
    Ui::casestatus *ui;
};

#endif // CASESTATUS_H
