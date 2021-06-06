﻿using System;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace RedSwanStore.Utils
{
    public class EmailService
    {
        public string AdminName { get; set; } = "Red Swan Store";
        public string AdminEmail { get; set; } = "redswanstore@yandex.ru";
        public string AdminPassword { get; set; } = "redswan";
        public string EmailServer { get; set; } = "smtp.yandex.ru";
        
        public string SendPasswordRecoveryEmail(string email, string name, string surname, string newPassword)
        {
            try
            {
                var emailMessage = new MimeMessage();
            
                emailMessage.From.Add(new MailboxAddress(AdminName, AdminEmail));
                emailMessage.To.Add(new MailboxAddress($"{name} {surname}", email));
                emailMessage.Subject = "Восстановление пароля Red Swan Store.";
                emailMessage.Body = new TextPart(TextFormat.Html) {
                    Text = "<h2 style=\"font-size:32px;line-height:36px;font-weight:500;padding-bottom:10px;color:#333;text-align:center\">" +
                           $"Здравствуйте, {name} {surname}," +
                           "</h2>" +
                           "<div style=\"font-size:17px;line-height:25px;color:#333;font-weight:normal\">" +
                           $"<p>Пароль Вашей учетной записи Red Swan Store {email} был успешно сброшен.</p>" +
                           $"<p>Ваш новый временный пароль: {newPassword}. Мы настоятельно рекомендуем Вам как можно скорее сменить этот пароль на придуманный Вами.</p>" +
                           "<p>Если Вы не сбрасывали пароль или считаете, что посторонние лица получили доступ к Вашей учетной записи, немедленно обратитесь в техническую" +
                           " поддержку или к администрации Red Swan Store.</p>" +
                           "<p>С уважением,</p>" +
                           "<p>Администрация Red Swan Store</p>"
                };


                using (var client = new SmtpClient())
                {
                    client.Connect(EmailServer, 25, false);
                    client.Authenticate(AdminEmail, AdminPassword);
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }
        
        
        public string SendTransactionCommitEmail(TransactionInfo info)
        {
            try
            {
                var emailMessage = new MimeMessage();
            
                emailMessage.From.Add(new MailboxAddress(AdminName, AdminEmail));
                emailMessage.To.Add(new MailboxAddress($"{info.UserName}", info.UserEmail));
                emailMessage.Subject = "Спасибо за покупку в Red Swan Store!";
                emailMessage.Body = new TextPart(TextFormat.Html) {
                    Text = $"<table style=\"background-color:#f1f1f1;min-width:600px\" width=\"100%\" bgcolor=\"#f1f1f1\"><tbody><tr><td style=\"min-width:600px\" width=\"100%\" valign=\"top\" align=\"center\"><center><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#f1f1f1\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr height=\"50\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"50\"> </td></tr><tr><td align=\"center\"><table style=\"min-width:600px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td valign=\"middle\" align=\"center\"><div style=\"max-height:50px\"><div><a href=\"https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc2/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__=v0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0=&__F__=v0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxp9CWnI6HiATIqGqMAM5P5DvA4NbIL3oT5CJ60BcBYDrzIAR5fJi2NnXDdoDiDAWJReuX0T42aqeHwU4gxhkcXa8vp1xEZ2hY1lHpCfuIGSsxFAxoogy4H36M41uqYKZe8suHaajpx5-pRC5sLQvv_Krp_MHdHwhBpFX1B6uoExtRpzHly5HE43sOW8XUKLj2bNLUdbKvFXQXgTFPteb5_t\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc2/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__%3Dv0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0%3D%26__F__%3Dv0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxp9CWnI6HiATIqGqMAM5P5DvA4NbIL3oT5CJ60BcBYDrzIAR5fJi2NnXDdoDiDAWJReuX0T42aqeHwU4gxhkcXa8vp1xEZ2hY1lHpCfuIGSsxFAxoogy4H36M41uqYKZe8suHaajpx5-pRC5sLQvv_Krp_MHdHwhBpFX1B6uoExtRpzHly5HE43sOW8XUKLj2bNLUdbKvFXQXgTFPteb5_t&source=gmail&ust=1623073210975000&usg=AFQjCNG4Nax7RKrMvudhoChpzruSHsgLTw\"><img alt=\"Red Swan Store\" src=\"https://i.ibb.co/YyHyyKh/Rew-Swan-Pic.png\" style=\"max-width:70px;height:auto;display:block;margin:0\" title=\"Red Swan Store\" class=\"CToWUd\" width=\"70px\" vspace=\"0\" hspace=\"0\" border=\"0\" align=\"none\"></a></div></div></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:560px\" width=\"560\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr height=\"50\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"50\"> </td></tr><tr><td style=\"font-family:arial,helvetica,sans-serif;font-weight:700;font-size:50px;color:#313131;text-align:left;line-height:75px\" width=\"560\" align=\"center\"><div style=\"text-align:center;line-height:75px\">Спасибо!</div></td></tr><tr height=\"30\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"30\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#f1f1f1\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px;background-color:#fff\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#ffffff\"><tbody><tr><td align=\"center\"><table style=\"min-width:560px\" width=\"560\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr height=\"30\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"30\"> </td></tr><tr><td style=\"font-family:arial,helvetica,sans-serif;font-size:16px;color:#313131;text-align:left;line-height:24px\" width=\"560\" align=\"center\"><div style=\"text-align:center;line-height:24px\"><span style=\"font-size:18px\"><strong>Здравствуйте, {info.UserName}!</strong></span><br>Благодарим вас за покупку у продавца «Red Swan Store».<br><br><span style=\"font-size:35px;line-height:45px\"><strong>Идентификатор счета:<br>{info.AccountIdentifier}</strong></span><br><span style=\"font-size:14px;color:#b2b2b2;line-height:40px\">( Советуем сохранить копию данного чека для отчетности. )</span></div></td></tr><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px;background-color:#fff\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#ffffff\"><tbody><tr><td align=\"center\"><table width=\"540\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td style=\"font-family:arial,helvetica,sans-serif;text-transform:uppercase;font-size:14px;color:#b2b2b2;text-align:left;line-height:24px\"><div style=\"font-family:arial,helvetica,sans-serif;font-size:14px;color:#b2b2b2;text-align:left\"><strong>ИНФОРМАЦИЯ О ВАШЕМ ЗАКАЗЕ:</strong></div></td></tr><tr height=\"1\"><td style=\"line-height:1px;font-size:1px;background-color:#e2e3e4\" width=\"100%\" height=\"1\"> </td></tr><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px;background-color:#fff\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#ffffff\"><tbody><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr><tr><td align=\"center\"><table width=\"540\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td><table style=\"min-width:270px\" width=\"270\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"left\"><tbody><tr><td align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-size:16px;color:#313131;text-align:left;line-height:24px\"><strong>Идентификатор заказа:</strong><br>{info.TransactionIdentifier}<br><br><strong>Дата заказа:</strong><br>{DateTime.Now.Date.ToShortDateString()}<br></div></td></tr></tbody></table><table style=\"min-width:270px\" width=\"270\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"right\"><tbody><tr><td align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-size:16px;color:#313131;text-align:left;line-height:24px\"><strong>Счет выставлен:</strong><br><a href=\"mailto:elgoogecaf@gmail.com\" target=\"_blank\">{info.UserEmail}</a><br><br><strong>Источник:</strong><br>Red Swan Store<br></div></td></tr><tr height=\"1\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"1\"> </td></tr></tbody></table></td></tr><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px;background-color:#fff\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#ffffff\"><tbody><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr><tr><td align=\"center\"><table width=\"540\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td style=\"font-family:arial,helvetica,sans-serif;text-transform:uppercase;font-size:14px;color:#b2b2b2;text-align:left;line-height:24px\"><div style=\"font-family:arial,helvetica,sans-serif;font-size:14px;color:#b2b2b2;text-align:left\"><strong>СОДЕРЖИМОЕ ВАШЕГО ЗАКАЗА:</strong></div></td></tr><tr height=\"1\"><td style=\"line-height:1px;font-size:1px;background-color:#e2e3e4\" width=\"100%\" height=\"1\"> </td></tr></tbody></table><table style=\"min-width:540px;background-color:#f1f1f1\" width=\"540\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#f1f1f1\"><tbody><tr><td align=\"center\"><table width=\"520\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr height=\"10\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"10\"> </td></tr><tr><td align=\"center\"><table width=\"260\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"left\"><tbody><tr><td><div style=\"font-family:arial,helvetica,sans-serif;font-size:14px;color:#313131;text-align:left\"><strong>Описание:</strong></div></td></tr></tbody></table><table width=\"140\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"left\"><tbody><tr><td><div style=\"font-family:arial,helvetica,sans-serif;font-size:14px;color:#313131;text-align:left\"><strong>Издатель:</strong></div></td></tr></tbody></table><table width=\"80\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"right\"><tbody><tr><td><div style=\"font-family:arial,helvetica,sans-serif;font-size:14px;color:#313131;text-align:right\"><strong>Цена:</strong></div></td></tr></tbody></table></td></tr><tr height=\"10\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"10\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px;background-color:#fff\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#ffffff\"><tbody><tr height=\"8\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"8\"> </td></tr><tr><td align=\"center\"><table width=\"520\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td><table style=\"min-width:100%\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"left\"><tbody><tr><td style=\"min-width:220px\" width=\"220px\" align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-size:14px;color:#313131;text-align:left;line-height:20px;word-break:break-all;padding:5px 5px 5px 0\">{info.GameTitle}</div></td><td style=\"min-width:140px\" width=\"140\" align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-size:14px;color:#313131;text-align:left;line-height:20px;word-break:break-all;padding:5px 5px 5px 0\">{info.GameDeveloper}</div></td><td style=\"min-width:80px\" width=\"80\" align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-size:14px;color:#313131;text-align:right;line-height:20px;word-break:break-all;padding:5px 0 5px 0\">{info.ResultPrice.ConvertToPrice()}</div></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr><tr><td align=\"center\"><table width=\"540\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr height=\"1\"><td style=\"line-height:1px;font-size:1px;background-color:#e2e3e4\" width=\"100%\" height=\"1\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px;background-color:#fff\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#ffffff\"><tbody><tr><td align=\"center\"><table width=\"520\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr><tr><td align=\"center\"><table width=\"412px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"left\"><tbody><tr><td><div style=\"font-family:Ariel,Helvetica,sans-serif;font-weight:700;text-transform:uppercase;font-size:14px;color:#b2b2b2;text-align:right;line-height:26px\">ИТОГО [ RUB ]:<br></div></td></tr></tbody></table><table width=\"80px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"right\"><tbody><tr><td align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-weight:700;font-size:14px;color:#313131;text-align:right;line-height:26px\">{info.ResultPrice.ConvertToPrice()}<br></div></td></tr></tbody></table></td></tr><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr><tr><td align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-size:14px;color:#313131;text-align:center;line-height:26px\">Цена с НДС (при его наличии).</div></td></tr><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px;background-color:#fff\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#ffffff\"><tbody><tr><td align=\"center\"><table width=\"540\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td style=\"font-family:arial,helvetica,sans-serif;text-transform:uppercase;font-size:14px;color:#b2b2b2;text-align:left;line-height:24px\"><div style=\"font-family:arial,helvetica,sans-serif;font-size:14px;color:#b2b2b2;text-align:left\"><strong>ИНФОРМАЦИЯ О ПЛАТЕЖЕ:</strong></div></td></tr><tr height=\"1\"><td style=\"line-height:1px;font-size:1px;background-color:#e2e3e4\" width=\"100%\" height=\"1\"> </td></tr><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px;background-color:#fff\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#ffffff\"><tbody><tr><td align=\"center\"><table width=\"540\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table width=\"450px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"left\"><tbody><tr><td><div style=\"font-family:Ariel,Helvetica,sans-serif;font-weight:700;text-transform:uppercase;font-size:14px;color:#b2b2b2;text-align:left;line-height:26px\">ОПЛАТА ПРИ ПОМОЩИ: <span style=\"color:#313131\">[RUB]:</span><br></div></td></tr></tbody></table><table width=\"80px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"left\"><tbody><tr><td align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-weight:700;font-size:14px;color:#313131;text-align:right;line-height:26px\">{info.ResultPrice.ConvertToPrice()}<br></div></td></tr></tbody></table></td></tr><tr height=\"20\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"20\"> </td></tr><tr height=\"1\"><td style=\"line-height:1px;font-size:1px;background-color:#e2e3e4\" width=\"100%\" height=\"1\"> </td></tr><tr height=\"20\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"20\"> </td></tr><tr><td align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-size:14px;color:#313131;text-align:center;line-height:26px;width:540px\">Любую игру, купленную в магазине Red Swan, можно вернуть в течение 14 дней после покупки (а в случае с предзаказами — в течение 14 дней после выхода игры), если вы играли в нее менее 2 часов.</div></td></tr><tr height=\"20\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"20\"> </td></tr><tr height=\"1\"><td style=\"line-height:1px;font-size:1px;background-color:#e2e3e4\" width=\"100%\" height=\"1\"> </td></tr><tr height=\"20\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"20\"> </td></tr><tr><td align=\"center\"><div style=\"font-family:Ariel,Helvetica,sans-serif;font-size:14px;color:#313131;text-align:center;line-height:26px\"><strong>Red Swan Store</strong><br>Санкт-Петербург, Невский Проспект 3, Россия<br></div></td></tr><tr height=\"50\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"50\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table style=\"min-width:600px\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><table style=\"min-width:600px\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr height=\"15\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"15\"> </td></tr><tr><td align=\"center\"><table style=\"min-width:560px\" width=\"560\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td align=\"center\"><div style=\"font-family:ariel,helvetica,sans-serif;font-weight:700;font-size:14px;color:#313131;text-align:center;line-height:26px\"><div style=\"font-family:arial,helvetica,sans-serif;font-weight:700;font-size:10px;color:#202020;text-align:center;line-height:12px\">Нужна помощь? <a style=\"text-decoration:none;color:#037aee\" href=\"https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc3/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__=v0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0=&__F__=v0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_30tcPSLyBQEVxcxZVIrRNjLGlO7ag0Cq_K8h1Z6eadrYqGqMAM5P5DvA4NbIL3oT5CJ60BcBYDrzIAR5fJi2NnXDdoDiDAWJReuX0T42aqeHwU4gxhkcXa8vp1xEZ2hY1lHpCfuIGSsxFAxoogy4H36M41uqYKZe8suHaajpx5-pRC5sLQvv_KbgJ6RNqv3a6bj857WamKMDVkmv-YTbgtTibsXe7F8UwzWRQznWHjsHgTFPteb5_t\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc3/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__%3Dv0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0%3D%26__F__%3Dv0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_30tcPSLyBQEVxcxZVIrRNjLGlO7ag0Cq_K8h1Z6eadrYqGqMAM5P5DvA4NbIL3oT5CJ60BcBYDrzIAR5fJi2NnXDdoDiDAWJReuX0T42aqeHwU4gxhkcXa8vp1xEZ2hY1lHpCfuIGSsxFAxoogy4H36M41uqYKZe8suHaajpx5-pRC5sLQvv_KbgJ6RNqv3a6bj857WamKMDVkmv-YTbgtTibsXe7F8UwzWRQznWHjsHgTFPteb5_t&source=gmail&ust=1623073210975000&usg=AFQjCNHe-_2ZPjtDIDfYW1cYsISgilZ4FQ\">redswanstore@yandex.ru</a><br></div><br></div></td></tr><tr height=\"20\"><td style=\"line-height:1px;font-size:1px\" width=\"100%\" height=\"20\"> </td></tr><tr><td align=\"center\"><div style=\"font-family:ariel,helvetica,sans-serif;font-size:12px;color:#858585;text-align:center;line-height:20px\"><p>© Red Swan, Inc., 2021 г. Все права сохранены. Red Swan, логотип Red Swan, Red Swan Store и логотип Red Swan Store являются товарными знаками или зарегистрированными товарными знаками Red Swan, Inc. в РФ и всём остальном мире. Все другие товарные знаки являются собственностью соответствующих владельцев.</p><br><a href=\"https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc4/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__=v0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0=&__F__=v0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxprPa-JJdz0Wq68mnO8WjEyqk9i5p-JcqZgG1_ILG8Gn6cl4NxEAb7a8APPjcfRNsdi1d4cXPgetoKDavBtCdOtvJz1YIXf_nU3wr_jQKReo2O6jhejqbVKwyn6RQNUYiregRLMYZi6Pz6FRxQDKUlILyRZ4ZJ9LSRTZ0YpODZwAFPx21Z366i3vMAuHMd-iimiH8ML8hr0E2-R_X-3D-F-TuYnTC-1zsA=\" style=\"color:#6bae7c\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc4/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__%3Dv0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0%3D%26__F__%3Dv0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxprPa-JJdz0Wq68mnO8WjEyqk9i5p-JcqZgG1_ILG8Gn6cl4NxEAb7a8APPjcfRNsdi1d4cXPgetoKDavBtCdOtvJz1YIXf_nU3wr_jQKReo2O6jhejqbVKwyn6RQNUYiregRLMYZi6Pz6FRxQDKUlILyRZ4ZJ9LSRTZ0YpODZwAFPx21Z366i3vMAuHMd-iimiH8ML8hr0E2-R_X-3D-F-TuYnTC-1zsA%3D&source=gmail&ust=1623073210975000&usg=AFQjCNFSYncVg0WN4fAdxs26kbclqF2pQA\"></a><a href=\"https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc5/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__=v0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0=&__F__=v0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxqdFzHYpPnL89HhrNBq3lw3tiE3xsAycXyuvJpzvFoxMqpPYuafiXKmYBtfyCxvBp-nJeDcRAG-2vADz43H0TbHYtXeHFz4HraCg2rwbQnTrbyc9WCF3_51N8K_40CkXqNjuo4Xo6m1SsMp-kUDVGIq3oESzGGYuj8-hUcUAylJSBKDznHggVoTQ4ta6_K-d34J2y5c9WaQw-j32rttLwXaMd-RfrOjbXJvkf1_tw_hfk7mJ0wvtc7A\" style=\"color:#037aee\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc5/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__%3Dv0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0%3D%26__F__%3Dv0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxqdFzHYpPnL89HhrNBq3lw3tiE3xsAycXyuvJpzvFoxMqpPYuafiXKmYBtfyCxvBp-nJeDcRAG-2vADz43H0TbHYtXeHFz4HraCg2rwbQnTrbyc9WCF3_51N8K_40CkXqNjuo4Xo6m1SsMp-kUDVGIq3oESzGGYuj8-hUcUAylJSBKDznHggVoTQ4ta6_K-d34J2y5c9WaQw-j32rttLwXaMd-RfrOjbXJvkf1_tw_hfk7mJ0wvtc7A&source=gmail&ust=1623073210975000&usg=AFQjCNEfBmSbKaPUjlCEvP0bg9kQ8gFdUQ\">Условия обслуживания</a> | <a href=\"https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc6/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__=v0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0=&__F__=v0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxp7JLvxiLMEAzZjdsyV3hB6TsAY9yft30UxmkMAQoHaNKLwMwlX2lTK68zF32zwJUh_6MAk3hYsl9oOkeJ4PQEwXtHtv3Sw9Ck-hUcUAylJSMYqr5Eyidlr6uBLAINIpGtjij1YsRtZ7BmgJIUGTBi7HsVaD9p-9vNlvbq1z7m6T2PoDnk1eDkldfOSzgrGqcVxwEZGgtRJriT3axMm8eajanttEuCEEOtFp0B5dGKYyw==\" style=\"color:#6bae7c\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc6/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__%3Dv0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0%3D%26__F__%3Dv0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxp7JLvxiLMEAzZjdsyV3hB6TsAY9yft30UxmkMAQoHaNKLwMwlX2lTK68zF32zwJUh_6MAk3hYsl9oOkeJ4PQEwXtHtv3Sw9Ck-hUcUAylJSMYqr5Eyidlr6uBLAINIpGtjij1YsRtZ7BmgJIUGTBi7HsVaD9p-9vNlvbq1z7m6T2PoDnk1eDkldfOSzgrGqcVxwEZGgtRJriT3axMm8eajanttEuCEEOtFp0B5dGKYyw%3D%3D&source=gmail&ust=1623073210975000&usg=AFQjCNFWAcY10fDwvSQDIgo9GthFjPrwNw\"></a><a href=\"https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc7/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__=v0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0=&__F__=v0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxqdFzHYpPnL83sku_GIswQDnxtEJE3LdSI4Qx4HJ7sxek7AGPcn7d9FMZpDAEKB2jSi8DMJV9pUyuvMxd9s8CVIf-jAJN4WLJfaDpHieD0BMF7R7b90sPQpPoVHFAMpSUjGKq-RMonZa-rgSwCDSKRrY4o9WLEbWewZoCSFBkwYux7FWg_afvbzZb26tc-5uk8oJEJKL28uy799BnZJfI1c9n7RY35POzsEl4mcQ0JoKLQj9mZL5OVXRadAeXRimMs=\" style=\"color:#037aee\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://accts.epicgames.com/T/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c960000021ef3a0bcc7/5cd7ab08-6bb4-4c96-a460-8f6ee247b238?__dU__%3Dv0G4RBKTXg2GsSUKeCIT0ZsixpTu2oNAqvl6X7t4UbJT0%3D%26__F__%3Dv0fUYvjHMDjRPMSh3tviDHXIoXcPxvDgUUCCPvXMWoX_0JoZLAZABQF2Skw9vkwo_mga2JAbIShxqdFzHYpPnL83sku_GIswQDnxtEJE3LdSI4Qx4HJ7sxek7AGPcn7d9FMZpDAEKB2jSi8DMJV9pUyuvMxd9s8CVIf-jAJN4WLJfaDpHieD0BMF7R7b90sPQpPoVHFAMpSUjGKq-RMonZa-rgSwCDSKRrY4o9WLEbWewZoCSFBkwYux7FWg_afvbzZb26tc-5uk8oJEJKL28uy799BnZJfI1c9n7RY35POzsEl4mcQ0JoKLQj9mZL5OVXRadAeXRimMs%3D&source=gmail&ust=1623073210976000&usg=AFQjCNGk1bUDHbWqq_SRC_X44eOEJ1kTGw\">Политика конфиденциальности</a></div></td></tr><tr><td style=\"color:#313131\" align=\"center\"> </td></tr><tr><td style=\"color:#313131;font-size:10px\" align=\"center\"><p></p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></center></td></tr></tbody></table><img src=\"https://ci3.googleusercontent.com/proxy/9nIeJfEjz2dCXIVnknb1Ep505H2Jr5OmvlwFN94BH_dKnYL53djBAM_Sf-vnbEIB8P4iRtEIiRHkmS24ldSbQpXgA3DmUDMzWickN622cwgNxVeyUnC4yrJwHQdXNyj3IDG1R-3rYg_wn3B35IGCm4_PEMyY=s0-d-e1-ft#https://accts.epicgames.com/O/v6200000179dbea005bcac425434b5c3b28/5cd7ab086bb44c9600004c5a42963aa1\" style=\"display:none;max-height:0;font-size:0;overflow:hidden\" class=\"CToWUd\">"
                };


                using (var client = new SmtpClient())
                {
                    client.Connect(EmailServer, 25, false);
                    client.Authenticate(AdminEmail, AdminPassword);
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }
    }

    public class TransactionInfo
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string AccountIdentifier { get; set; }
        public string TransactionIdentifier { get; set; }
        public string GameTitle { get; set; }
        public string GameDeveloper { get; set; }
        public decimal ResultPrice { get; set; }
    }
}