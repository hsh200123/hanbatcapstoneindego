using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �̹� �ۼ��� �ڵ忡�� ����&���� �ؾ��Ұ�
 *  1. �÷��̾� ����, ���� ���� ���� ����(�������� ���ÿ� Collider�� �������� �ø� �����ؼ� List���� ���)
 *  2. �÷��̾� �ǰ� �� �÷��̾� �ൿ ���� ���(���� ��� ���� ���� ������ ���� ���, ���и� �ݴ�� ����� �� �ǰ� �� ���� ���� ���)
 *  3. ���� �ǰ� �� ���� �ൿ ���� ����(���� ��� ���� ���� ������ ���� ���, ���۾Ƹ� ���� �߰�)
 *  4. ���� ���� �� ��ų ��� �� Velocity ����
 *  5. Stat�� ���� ���ݿ� ����� �����Ű��
 *  6. ���� óġ �� ����ġ �� ��� ȹ��
 *  7. Weapon�� �÷��̾��� Core�� �޾ƿͼ� ������ ���߱�
 *  8. Weapon�� �� State�� �޾ƿ��� ��Ŀ��� ������ �и��ؼ� ������ ���߱� -> ����
 *  9. �и� ���� �� �и� Ű Hold ���¸� �ٽ� �и� ���·� ���� ���� ����
 *  10. ������ ������� �� ������ �߰��� ����ϰ� �и��� �� �� �ִ� ���·� ��ȯ�ϴ� ���� ����
 *  11. ���� �и� �� ���� �� �˹� �ܰ迡�� �ٴ� �� �κ��̸� �������� �ʰ� �ϱ�
 *  12. �÷��̾ ���� �� �а� �ϱ�
 *  
 *  13. ȭ�� �浹�� ���Ͱ� �ƴ� �ٸ� ��ü�� ��Ƶ� �����ǰ�
 *  14. ��ųState �߻�ȭ��Ű��
 *  15. ȭ�� �߻� Ÿ�̹� ����
 *  16. ȭ�� Ȧ�� �� ���� �ӵ��� �̵��ϱ�
 *  17. SkillFireState �����ϱ�
 *  18. �޾ƿ� ���� �� Ȱ���ϱ�




 * �߰��� �ۼ�&���� �ؾ��Ұ�
 *  1. �и� ���� �� ������ �����̻� �ο�(���� ��)
 *  2. ��ų/������ ��� �� ȿ�� ����(���� �ӵ�, �̵� �ӵ�, ���ݷ� ��)
 *  3. �� ȯ���� ���� ȿ�� ����(���� �ӵ�, �̵� �ӵ� ��)
 *  4. Stat Ŭ������ ����,�÷��̾� ������ �и�
 *  5. �и� ���� �� �߰� ���ݷ��� ����
 *  6. Json ������ ���� �÷��̾� ���� ��ġ �ۼ�
 *  7. �Է��� �÷��̾� �Է� / UI�Է� �и�
 *  8. �ֻ��� State����(�Ͻ���������, �������)
 *  9. �����͸� ��� �̾ƿ� ���ΰ� (�������� �� / �÷��̾� ���� ���� / n�ʴ� �̵����� / ���� �ֱ� / �и� Ƚ�� / �и� ���� Ȯ�� / �и� ��-�� �ൿ���� / ȸ�� Ƚ�� / ȸ�� ���� Ȯ�� / ȸ�� ��-�� �ൿ����)
 *  10. Monster ObjectPool �ۼ�
 *  11. Monster Spowner �ۼ�
 *  12. Dead ���� �÷��̾� / ���� �ڵ� �ۼ�
 *  13. Damage�� ���� ���� ������ �ִ� ���� ���������� ����ϴ� Ŭ���� ���� (�� ���� -> �÷��̾� ���� + �Ӽ��� ���� ������ ����/���� + ��ų �� ������ ����� ���� ������ ���� + ���� �߰� ���� ��ȭ ȿ��)

 */