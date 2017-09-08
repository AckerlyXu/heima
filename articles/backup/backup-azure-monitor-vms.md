---
title: Monitor Resource Manager-deployed virtual machine backups | Microsoft Docs
description: Monitor events and alerts from Resource Manager-deployed virtual machine backups. Send email based on alerts.
services: backup
documentationcenter: dev-center-name
author: alexchen2016
manager: digimobile
editor: ''

ms.assetid: fed32015-2db2-44f8-b204-d89f6fd1bea2
ms.service: backup
ms.workload: storage-backup-recovery
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 03/21/2016
ms.date: 09/04/2017
ms.author: v-junlch

---
# Monitor alerts for Azure virtual machine backups
Alerts are responses from the service that an event threshold has been met or surpassed. Knowing when problems start can be critical to keeping business costs down. Alerts typically do not occur on a schedule, and so it is helpful to know as soon as possible after alerts occur. For example, when a backup or restore job fails, an alert occurs within five minutes of the failure. In the vault dashboard, the Backup Alerts tile displays Critical and Warning-level events. In the Backup Alerts settings, you can view all events. But what do you do if an alert occurs when you are working on a separate issue? If you don't know when the alert happens, it could be a minor inconvenience, or it could compromise data. To make sure the correct people are aware of an alert - when it occurs, configure the service to send alert notifications via email. For details on setting up email notifications, see [Configure notifications](backup-azure-monitor-vms.md#configure-notifications).

## How do I find information about the alerts?
To view information about the event that threw an alert, you must open the Backup Alerts blade. There are two ways to open the Backup Alerts blade: either from the Backup Alerts tile in the vault dashboard, or from the Alerts and Events blade.

To open the Backup Alerts blade from Backup Alerts tile:

- On the **Backup Alerts** tile on the vault dashboard, click **Critical** or **Warning** to view the operational events for that severity level.

    ![Backup Alerts tile](./media/backup-azure-monitor-vms/backup-alerts-tile.png)

To open the Backup Alerts blade from the Alerts and Events blade:

1. From the vault dashboard, click **All Settings**. ![All Settings button](./media/backup-azure-monitor-vms/all-settings-button.png)
2. On the **Settings** blade, click **Alerts and Events**. ![Alerts and Events button](./media/backup-azure-monitor-vms/alerts-and-events-button.png)
3. On the **Alerts and Events** blade, click **Backup Alerts**. ![Backup Alerts button](./media/backup-azure-monitor-vms/backup-alerts.png)

    The **Backup Alerts** blade opens and displays the filtered alerts.

    ![Backup Alerts tile](./media/backup-azure-monitor-vms/backup-alerts-critical.png)
4. To view detailed information about a particular alert, from the list of events, click the alert to open its **Details** blade.

    ![Event Detail](./media/backup-azure-monitor-vms/audit-logs-event-detail.png)

    To customize the attributes displayed in the list, see [View additional event attributes](backup-azure-monitor-vms.md#view-additional-event-attributes)

## Configure notifications
 You can configure the service to send email notifications for the alerts that occurred over the past hour, or when particular types of events occur.

To set up email notifications for alerts

1. On the Backup Alerts menu, click **Configure notifications**

    ![Backup Alerts menu](./media/backup-azure-monitor-vms/backup-alerts-menu.png)

    The Configure notifications blade opens.

    ![Configure notifications blade](./media/backup-azure-monitor-vms/configure-notifications.png)
2. On the Configure notifications blade, for Email notifications, click **On**.

    The Recipients and Severity dialogs have a star next to them because that information is required. Provide at least one email address, and select at least one Severity.
3. In the **Recipients (Email)** dialog, type the email addresses for who receive the notifications. Use the format: username@domainname.com. Separate multiple email addresses with a semicolon (;).
4. In the **Notify** area, choose **Per Alert** to send notification when the specified alert occurs, or **Hourly Digest** to send a summary for the past hour.
5. In the **Severity** dialog, choose one or more levels that you want to trigger email notification.
6. Click **Save**.

   ### What alert types are available for Azure IaaS VM backup?
   | Alert Level | Alerts sent |
   | --- | --- |
   | Critical |Backup failure, recovery failure |
   | Warning |None |
   | Informational |None |

### Are there situations where email isn't sent even if notifications are configured?
There are situations where an alert is not sent, even though the notifications have been properly configured. In the following situations email notifications are not sent to avoid alert noise:

- If notifications are configured to Hourly Digest, and an alert is raised and resolved within the hour.
- The job is canceled.
- A backup job is triggered and then fails, and another backup job is in progress.
- A scheduled backup job for a Resource Manager-enabled VM starts, but the VM no longer exists.

## Customize your view of events
The **Audit logs** setting comes with a pre-defined set of filters and columns showing operational event information. You can customize the view so that when the **Events** blade opens, it shows you the information you want.

1. In the [vault dashboard](backup-azure-manage-vms.md#open-a-recovery-services-vault-in-the-dashboard), browse to and click **Audit Logs** to open the **Events** blade.

    ![Audit Logs](./media/backup-azure-monitor-vms/audit-logs-1606-1.png)

    The **Events** page opens to the operational events filtered just for the current vault.

    ![Audit Logs Filter](./media/backup-azure-monitor-vms/backup_event.png)

    The page shows the list of Critical, Error, Warning, and Informational events that occurred in the past week. The time span is a default value set in the page. For information about exposing additional Event attributes, see the section [expanding Event information](backup-azure-monitor-vms.md#view-additional-event-attributes).
2. For additional information on an operational event, in the **Operation** column, click an operational event to open its blade. The blade contains detailed information about the events. Events are grouped by their correlation ID and a list of the events that occurred in the Time span.

    ![Operation Details](./media/backup-azure-monitor-vms/audit-logs-details-window.png)
3. To view detailed information about a particular event, from the list of events, click the event to open its **Details** blade.

    ![Event Detail](./media/backup-azure-monitor-vms/audit-logs-details-window-deep.png)

    The Event-level information is as detailed as the information gets. If you prefer seeing this much information about each event, and would like to add this much detail to the **Events** blade, see the section [expanding Event information](backup-azure-monitor-vms.md#view-additional-event-attributes).

## Customize the event filter
Use the **Filter** to adjust or choose the information that appears in a particular blade. To filter the event information:

1. In the [vault dashboard](backup-azure-manage-vms.md#open-a-recovery-services-vault-in-the-dashboard), browse to and click **Audit Logs** to open the **Events** page.

    ![Audit Logs](./media/backup-azure-monitor-vms/audit-logs-1606-1.png)

3. On the event page, adjust the filter items.

    ![Audit Logs-query details](./media/backup-azure-monitor-vms/backup_event.png)

    You can specify the **Event severity** of event: Critical, Error, Warning, or Informational. You can choose any combination of event Levels, but you must have at least one Level selected. Toggle the Level on or off. The **Timespan** filter allows you to specify the length of time for capturing events. If you use a custom Time span, you can set the start and end times.
4. Once you are ready to query the operations logs using your filter, click **Apply**. 

### View additional event attributes
Using the **Columns** button, you can enable additional event attributes to appear in the list on the **Events** blade. The default list of events displays information for Operation, Level, Status, Resource, and Time. To enable additional attributes:

1. On the **Events** page, click **Columns**.

    ![Open Columns](./media/backup-azure-monitor-vms/backup_event_column_btn.png)

    The **Choose columns** blade opens.

    ![Columns blade](./media/backup-azure-monitor-vms/backup_event_column.png)
2. To select the attribute, click the checkbox. The attribute checkbox toggles on and off.
3. Click **Reset** to reset the list of attributes in the **Events** blade. After adding or removing attributes from the list, use **Reset** to view the new list of Event attributes.
4. Click **Done** to update the data in the Event attributes. The following table provides information about each attribute.

| Column name | Description |
| --- | --- |
| Operation name|The name of the operation |
| Status |Descriptive state of the operation |
| Event Category |Category of the event |
| Time |Time, measured from the current time, when the event occurred |
| Timestamp |The time when the event was triggered |
| Subscription |The associated subscription|
| Event initiated by | Specify the caller who initiated the event. |
| Resource Type |The internal resource type used by Resource Manager |
| Resource |URL that identifies the resource; also known as the resource ID |

## Next steps
Event logs enable great post-mortem and audit support for the backup operations. The following operations are logged:

- Register
- Unregister
- Configure protection
- Backup (Both scheduled as well as on-demand backup)
- Restore
- Stop protection
- Delete backup data
- Add policy
- Delete policy
- Update policy
- Cancel job

For information on re-creating a virtual machine from a recovery point, check out [Restore Azure VMs](backup-azure-restore-vms.md). If you need information on protecting your virtual machines, see [First look: Back up VMs to a Recovery Services vault](backup-azure-vms-first-look-arm.md). Learn about the management tasks for VM backups in the article, [Manage Azure virtual machine backups](backup-azure-manage-vms.md).

