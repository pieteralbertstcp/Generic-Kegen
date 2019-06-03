using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace KeyGen
{
    internal class KeyGenUI
    {
        private readonly List<string> keys;

        internal KeyGenUI(List<string> keys)
        {
            this.keys = keys ?? new List<string>();
        }

        internal Form GetWindow(string windowTitle)
        {
            Form form = new Form
            {
                Size = new Size(300, 150),
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                StartPosition = FormStartPosition.CenterScreen,
                BackgroundImage = GetBackgroundImage(),
                BackgroundImageLayout = ImageLayout.Tile,
                Text = "KeyGen - " + windowTitle
            };

            Label lblTitle = new Label
            {
                Text = windowTitle,
                Font = new Font(new FontFamily("Arial"), 10, FontStyle.Bold),
                Location = new Point(30, 15),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Width = 300
            };

            TextBox txtBox = new TextBox
            {
                Name = "txtKey",
                TextAlign = HorizontalAlignment.Center,
                Location = new Point(30, 40),
                Width = 230,
                ReadOnly = true
            };

            Button btnExit = new Button
            {
                MinimumSize = new Size(100, 20),
                Location = new Point(30, 80),
                Text = "Exit",
                Width = 100
            };

            Button btnGenerate = new Button
            {
                MinimumSize = new Size(100, 20),
                Location = new Point(160, 80),
                Text = "Generate",
                Width = 100
            };

            btnExit.Click += new EventHandler(ExitClick);
            btnGenerate.Click += new EventHandler(GenerateNewKeyClick);

            form.Controls.Add(lblTitle);
            form.Controls.Add(txtBox);
            form.Controls.Add(btnExit);
            form.Controls.Add(btnGenerate);

            return form;
        }

        private void ExitClick(object obj, EventArgs args)
        {
            Application.Exit();
        }

        private void GenerateNewKeyClick(object obj, EventArgs args)
        {
            ((Button)obj).Parent.Controls.Find("txtKey", true).FirstOrDefault().Text = GetNextKey();
        }

        private string GetNextKey()
        {
            return keys.Count() == 0 ? "NO KEYS !" : keys[new Random().Next(0, keys.Count())];
        }

        private Image GetBackgroundImage()
        {
            return Image.FromStream(new MemoryStream(Convert.FromBase64String(Base64BackGroundImage())));
        }

        private static string Base64BackGroundImage()
        {
            return @"/9j/4AAQSkZJRgABAQAAAQABAAD/4QNwRXhpZgAATU0AKgAAAAgABwESAAMAAAABAAEAAAEaAAUA
                    AAABAAAAYgEbAAUAAAABAAAAagEoAAMAAAABAAIAAAExAAIAAAAIAAAAcgE7AAIAAAAHAAAAeodp
                    AAQAAAABAAAAggAAAAAAAABIAAAAAQAAAEgAAAABUGljc0FydABncmlnMTUAAAAIkAAABwAAAAQw
                    MjIxkQEABwAAAAQBAgMAkoYABwAAAoAAAADooAAABwAAAAQwMTAwoAEAAwAAAAEAAQAAoAIABAAA
                    AAEAAAEAoAMABAAAAAEAAAEApAYAAwAAAAEAAAAAAAAAAEFTQ0lJAAAAeyJ0b3RhbF9lZmZlY3Rz
                    X2FjdGlvbnMiOjAsInRvdGFsX2RyYXdfdGltZSI6MCwibGF5ZXJzX3VzZWQiOjAsImVmZmVjdHNf
                    dHJpZWQiOjAsInRvdGFsX2RyYXdfYWN0aW9ucyI6MCwidG90YWxfZWRpdG9yX2FjdGlvbnMiOnsi
                    Ym9yZGVyIjowLCJmcmFtZSI6MCwibWFzayI6MCwibGVuc2ZsYXJlIjowLCJjbGlwYXJ0IjowLCJ0
                    ZXh0IjowLCJzcXVhcmVfZml0IjowLCJzaGFwZV9tYXNrIjowLCJjYWxsb3V0IjowfSwiZWZmZWN0
                    c19hcHBsaWVkIjowLCJ1aWQiOiI4MDkzRTI3QS1CN0ZCLTRGOEEtQjRGRi1FQzdFRUY2QUYxRTBf
                    MTQ1ODQ2OTQzMDAyOSIsIndpZHRoIjozODQwLCJwaG90b3NfYWRkZWQiOjAsInRvdGFsX2VmZmVj
                    dHNfdGltZSI6MCwidG9vbHNfdXNlZCI6eyJ0aWx0X3NoaWZ0IjowLCJyZXNpemUiOjAsImFkanVz
                    dCI6MCwiY3VydmVzIjowLCJtb3Rpb24iOjAsInBlcnNwZWN0aXZlIjowLCJjbG9uZSI6MCwiY3Jv
                    cCI6MCwiZW5oYW5jZSI6MCwic2VsZWN0aW9uIjowLCJmcmVlX2Nyb3AiOjAsImZsaXBfcm90YXRl
                    IjowLCJzaGFwZV9jcm9wIjowLCJzdHJldGNoIjowfSwib3JpZ2luIjoiZ2FsbGVyeSIsImhlaWdo
                    dCI6NTc2MCwidG90YWxfZWRpdG9yX3RpbWUiOjAsImJydXNoZXNfdXNlZCI6MH3/7QA4UGhvdG9z
                    aG9wIDMuMAA4QklNBAQAAAAAAAA4QklNBCUAAAAAABDUHYzZjwCyBOmACZjs+EJ+/+ICQElDQ19Q
                    Uk9GSUxFAAEBAAACMEFEQkUCEAAAbW50clJHQiBYWVogB88ABgADAAAAAAAAYWNzcEFQUEwAAAAA
                    bm9uZQAAAAAAAAAAAAAAAAAAAAAAAPbWAAEAAAAA0y1BREJFAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                    AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAKY3BydAAAAPwAAAAyZGVzYwAAATAAAABrd3RwdAAA
                    AZwAAAAUYmtwdAAAAbAAAAAUclRSQwAAAcQAAAAOZ1RSQwAAAdQAAAAOYlRSQwAAAeQAAAAOclhZ
                    WgAAAfQAAAAUZ1hZWgAAAggAAAAUYlhZWgAAAhwAAAAUdGV4dAAAAABDb3B5cmlnaHQgMTk5OSBB
                    ZG9iZSBTeXN0ZW1zIEluY29ycG9yYXRlZAAAAGRlc2MAAAAAAAAAEUFkb2JlIFJHQiAoMTk5OCkA
                    AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                    AAAAAAAAAAAAAAAAAAAAAAAAAAAAAFhZWiAAAAAAAADzUQABAAAAARbMWFlaIAAAAAAAAAAAAAAA
                    AAAAAABjdXJ2AAAAAAAAAAECMwAAY3VydgAAAAAAAAABAjMAAGN1cnYAAAAAAAAAAQIzAABYWVog
                    AAAAAAAAnBgAAE+lAAAE/FhZWiAAAAAAAAA0jQAAoCwAAA+VWFlaIAAAAAAAACYxAAAQLwAAvpz/
                    2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUV
                    DA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQU
                    FBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCAEAAQADASIAAhEBAxEB/8QAHAAAAgMBAQEBAAAA
                    AAAAAAAABQYDBAcCCAEA/8QAPRAAAQMDAwIFAgQFBAICAQUAAQIDEQAEIQUSMQZBEyJRYXEHgTKR
                    ofAUI0KxwRVS0eEIMyTxFkNEYmNy/8QAFwEBAQEBAAAAAAAAAAAAAAAAAQACA//EABwRAQEBAAID
                    AQAAAAAAAAAAAAABESExAhJBUf/aAAwDAQACEQMRAD8A8xfQ76np0e9Gjao6VWT6gkKWfw16FVp6
                    GVhTaUqbKCpC0pnE/rXhkLU0+HEHatOZHrXpX6F/VBvqGzRoOqvBNygbWHFHn2p8b8apl6qsTaLK
                    2iUoCdsDIApUvGFOXCdwBVHmIwKfOoWCEvlUd+8cc0rtW3iKUtRJJ4NawSqNraiYj/qrjemID/iA
                    ncPeB81ZatfDIEhITncrFBOoPqRoPTqVNu3IfuQY8JkblT/YVYtTanh9IKAsjMHvSnq+hNoube9T
                    DS943A4B+KVtd+qeq6kpSNNYb05o48VcLd/XA+350m3Op3r92l1+7efdSZ8RxwqUfzrFwzXo/TtH
                    CChaxvScgEfr/er13bJSISAE9pFU/o31Padd6CvT1vJ/1S0wN6olP+eP1pnv9JWh/wAKIIE8gjic
                    R7VYme6lb7lFQge1LN61seHNabrWii1yUJTuTMH5PH5RSVrFqEuMkpgyQRGaMIWzblcxgnOOwomz
                    ZKiUiSrAr7bW4SwpUzMAnirdxdJsbFb0eZIgT60gt6y4kXXgIVKGfLPqe5rm1V4KEEkH39KqHK1K
                    HKjNTuO7UgdxkgVml3qrQurMZ/B5hOIpVW8GwRIXTJcndbAFR82Ck/NLT9v4bqk45x7UFUeWp2Sq
                    fvVixt4Vv2wCcV0lncY9atNANiB+ccUhYCoEA5pl+nNx4HUrQJP8xJHvStuAPaaLdIP/AMP1DYL/
                    AP7AkmtQXpq2q35BX5SBPp+tKOpXQK3IwSfvRvqN0tXSkgwJn/7pUuXNxySazTELjpJya4KpBqJS
                    jOK6QlSoAmgvvimSTxUrbe8A1I1aQJPNW2WYCe2IMUgOetZkjI9Iqk61sSRtg4zTC6zjA45qopoO
                    pKSK0AMz3HaonB6ZoldWS2xKRIGZoYsFBzge9SZuJ3QRE813Yao/oupNXtuoocbUD5T704M9FIuC
                    FFZAnIT3oux0ZpzAJNv4qgJO8zFGFpNj9V9K1zo9i81C4btbpvyu7hEiOQKU9X+s9i0hSNLt1XSu
                    A4sQmhNzoNnqe+3W0lsNo2o2DAPxSfqGhr0tSkPmE7vKtPete1GJtd6417qALDtybdkmPDZxNA2b
                    cNqKolRH4iZNToUlBDZBJ5BrsOpKk7EgpPYZIrNumTH0NFTY8sk81Aq13JKoIogkKUEkCB7jI+ak
                    bAWiMAdjFZKn0zr970R1Db6nZOBCkKhQIkKHcGvZGlavZfUHpi11WwUUOuNwrd/Sv+oH9+leNtQZ
                    3NFQE5wRT/8AQf6k/wD4prp0nUXS3pN/CFK3R4S+ErH74NbjNbnqglIaUEtKbUUFETGBPbnArO9f
                    Z2vM8kyZTHf0xWw9RaElq6TsClJWJJBBB98+1Zd1Ux/Cv2wDZQAoKCTz+ff1qSh/CKbtWNwA3Er2
                    j37Uv9TX4Vdt2aFHYyBv+TThqd01Z6eu7cISywjeok4+J9zisstrh29eduXFlS3Vlau3uB+v503i
                    JdcENgj17mvnjYzmB6VG45vMSIHaopMH0rmUy171cVVuGitc8fapUyTAE1IGFEGRUg8thInvUSlZ
                    5zRJy1Khxmh71qtJkpJTOQDFKQqdlXl9YFT2V14F3buzt8N1Kv1qkpK0qiD6zXwk+EccZj4pibL1
                    K54igufxAKT8Ed6U3iSZpguXTeWFgUpKlLYQYHxzVZGkbPO6JPp2rNUBmbRbpkiE0SZtktoj8qmd
                    b8MGK+NqPHpxNRftmDj86laZJzXeyQPep2Bs4xmoIri1PhiBn9KpJACjKY7UwAJdSElPm9qCXiPB
                    uFBOQTWonwhJSAQIPFBdQsA8CUQO+KJOqAMg1WUrdPGPWmhFaJCBHJHHzUhXhzGAkk+sAT/ipri2
                    NnqD1sQSUKKgTjFU3gf4ZwiPOQ3PfPP9qU50/cEBSk+dfmV3zX7UUWtyytL6QpKRMkfh9ya/T4bO
                    0mcce1QrJS0POBzEHisonaroTto8SPMgGQpI5+feqXhLVdkKHmWqZAgQfinZx8LiZXgEjBkULubV
                    CwVIBCDkJjJmrCEhtDfhkkzwpMQfmhzjyy7JPlBgTI/vRu7s1i3QQognCSvt+ke00EubdxJ3eHAP
                    KCTBPv8APtUkKLxLaodhSBjmc1Uu3FKe8dBEg4I/p9K+3CEhxJMgrMD5gmoXEw3BUSPSag9Z/Qj6
                    gp+oXSH+g376RrOnNwwtXLzXYfKcD8vmhf1NtVWd+0pWd6wdwGOK87dH9T3fRvUVpqlqotusrkzw
                    R6H2r0x13rdj1vpGg9QWqktWdztFwqf/AErT/wCwHthJBn0itfAzT6oakLfTrHS2yUl7a89zO0Rt
                    H55pasVA2yChWDnHeoepNTc6m6hurlDakJUrYhCslKAISn7CB9qYtB6M1C8YStTa0M/7iI+1Zpga
                    lO8REzirDenOKyobQfam5rp9qxbSrZvcHMiqzjAPx7+tZIMzYpRymraLIKRMA+kVfRalRgd+KJ2+
                    n7miCk7o+KYigpsB0oIGcSRU6bBLwnZJ+Kkv7QtX6khPxRSzaShABHHtW8ZCP9EbWohSMkZ7Gob/
                    AKes7bTnHnEk+XaiD3/YpvaYCoAAByaV+qroXF0m2QZbZ5HqaMhU9B+ptnpaEafqFqUqYT4fiJ5K
                    RxTVbdT6Xq4Cre5TnsrBFY11VZFD6LhIiRtJB/KgzbrjQ8RtxSFDuDWS3x8oVJBnOIrlKJVNY1p/
                    WOpWKgPFU4kdl02aP9SmipKbtvYf93aak0UM+Ue3tUzbXehdh1Tp+pJHgvpPAyaMNrBjaoEETiha
                    nbbkjiRFDuoLeEtvAbfiijawFZPtUWotC5tHEyVGDSiipUj3NV1mZq2hM4M4kQKFaxcizaMCFHgU
                    g2da2Zs7xi5T+FQ8Mn37UrvL3FCAZ2jcfk/9R+dPGsarpnWOgXDunXQdUlPiBtWFpiDkf8UmWdhe
                    am+r+Gt3HkkwCE4A7ZrVERre3CJ2n0jmqSlLcUYSVkngU76X9Orm4VvvHNg7pT/zTppnR1hp4BS0
                    lazjdEn9/FGFkOnaDePLSs20gSRvkHj5q2NEDLITshQHNa5qGjtlvDYGe4iP3NK+qaaq3UCUgJiJ
                    j2NOJn7lsS34K20lKfwk8gGQf7/pVd3Sbd1I3Npn1oteoLT5CgraSBMTHpJHFQbAs+lZIO90va3E
                    YKfioFfT1m5ICXFAHiaZ2EJA4k0a063T4Sn3lJbYR+JazAqnKIDP0guL0ww8CTjbBz7Yqbcv6fWl
                    1oNxrDb7Fy4hS2rcBxTZn0MgEgkY7GrHXX1kRpds9pmgmXiChdyn+mRwD6/v4w568U66u5fcW6sm
                    SVKyfafzquToTl7L+lXTHQ+o2yHdKvWbm6Jkm6wpP2PFN3VNkzpDaUKcbUlUkeGQY/L54rwpoutX
                    +iXjdxp147bupIUAlZAxxP8AxWydN/XK51Zlm114JC2//W+j8B9lD781SzFlPmo3AUs7ISnMJSIi
                    hmCTnivqdRZv0eIy4laVZBSZrgmOMmslat2/HeAOO2KZrDT9rQ2gmcGOKAaOofxKARAPJNPVsztQ
                    SSQQZ9jWoKQOpNPDOoNrmEkQaiYa3qk8d6YerrcHwlA7oVBz+/SgzEBUT5ua0H6/vEadZuvKxtGK
                    QVLL6lLWZUoyaMdY3/jXCbRtQUE+ZcHk+lAmyM5+9ZtMVtX04Xdo4iM9qRS14alBUyMVpChuSQaT
                    Nbsf4a8WoDCzI+ayQhbQ/FH51+8JMScGKteESkYgnGK/FmQfT1FSRMJcDqfDWoHttJpm0zqrVNO2
                    hNwVo9FiaXm0qb7QcVMt8bYMY71JpGmfUsOAC6bSk9yDzTXo3U2n6odguEIKhhKzE/esDcuNxVGT
                    nNXtJ07UNQW2GCppvkuHj7etKa7qSBYvvEeYbpEH1pF1q8VdPABUgZPyef8AFE1suf6YhkvuLeBy
                    tR/EBQNxgtqUCCFVW/FEHS1g+3cB4LW2gdgfx+1Mlv8AVzX/AKe3yrK6tmtV07lrckIcCSeAoYx7
                    iubRISttKRiQMVx1tpiL7T/Inc62NyfWf8U9BrvRX1j6V6yDbKLxOn3p/wD2t5CDPoDwa0ZDOxrd
                    AKTkKA7GvArlql2VFJStPB4NN/SP1g6u6BhNpqC7uzBhVpd+dPwJyPtT7fqx7EuGdyVzBUkzED98
                    Urara+Ml1ZBXtyVE8fuaTOkf/JPQNfhnWGV6RdL8u5R3NH4VyPuPvT866xqrSHbZ5u6tnRubcaVu
                    CuO4J5poZprVvD0hMGKGpayT29KauobQeIYAndjvSXr+uWvT4UHVpLx4bBzNZKd+5asGi68sIQM5
                    NZt159RH9VaXZ2xLNoE7Z43j/j996GdT9XLvnHAtalACQEGB9v8Amkt9RVEI2JGcgyf+ftRuHNdp
                    eAPonJkifvVS5fFy+UbZgpTtA47Hj4/Wo1uEAEAqAP8AjmqwP89e5J3KXk+vtist4YdMVK0iN2IJ
                    A7/ejCWVQe8YwK40tDaGz5QS5AJMxI7/AH/zRQtEpwPzFLL5pmu3ukL3MPKSP9s4I+Ke9C+oNvc7
                    UXn8pfG/tWerZHpA44qJTJB9Kg9I9MlrUHEKZUlxJjzJVxWgplhgpgAxxxXjnR+rtX6ZukOWFy4h
                    STO3tW0dJ/Xa21dLTOsthh+B/MH4T71qYzTr1CjdZukmSFbvjNLFzdIsWF3BAKkphI5pxdVb6xpT
                    y7ZwPJKCQUmRxWYa9cKvXBbNgw3lZGc+9WkDLhu7h1xSlblGZPf94r6EkZMDOa+XG5mB4ZM4JAiK
                    /FahkpVB9RWUmQZEA+b09aH6zYJeQD9wRUgKw9uAj9KtFQdbzSij/DJbcnbvA7KqJxuDjIo7cWoC
                    zAiqi7X2NBCFJCTjHzXDdk7eOBDaSskdhxR9jRw55lyE+3NE7dlq1G1CNmeAINMiUtH6UabIcuQl
                    xXISRgUyEItm0hISkxA2iobZaifmuXnQVgTMVroJFKCQBPAiqdwwl9M8Hsa7L28VyF7sx+tYKSyV
                    uu2k4mCav3X80EEdqo6esKuJMGEQAauPqn3rV6DOuptJNjeF1AhDhkR2NBFMhQgitH1S0TqFo4gj
                    PaRFIlxalhZSoRBiskJcsC2VDIUJwcEUX6X6l1jpq5CtM1J+zJO4tgy2flJwaiKN2fgYEVXFtLqQ
                    M+x7VJqlh9Vdb6wcTpare1a1R8EN3IEAqj04mlLqHoHXrW4W9fsPXS1KlT34+fbtQ1NyrSXbW6t5
                    Dtu4lxKgcyO+K9T9KX9p1joFvdrbbKVJBWkRIUBkd4A/zTyunjnU9BUCt0qUFkbSkjM8Y70FduGl
                    pTIUpKcEq9PQ+nFe09Z+m2m6kVeJbtLG3fOyJHvWU9WfQ7T0sOFthbDgUVb2jMz7Rx6ZirFK8/Mg
                    JQ4+laf5QBSMyok9oqJDSVPDyuOkq3ScEExu4n3+ZmmzXOg7rRw62jzoUfxKBBJ5j9BwaDt6S4m4
                    CSnakOHtEZoaH7NPgtNDaANoP7/OiqEpU35f1z+tVTaIUlKY2KInJj3ri3/iEkoSiTJxFOMp3EAg
                    kEbfbiqzxAKjMkUZsumL+/cJUtKEEd0zNNGl/TW1V5rp1Tv/APEYFWDWXO73lgbd0nsMmi2l9Jat
                    qak/w9i4UHha07R+ZratO6W03TQksWje4YCiJMfJq1cXiLZskhKEjOKcWkjQNO1nou3N1caollHA
                    tmyVk+09qMaDrfTOrlVvfXV3p18TBUraptefXkfeaA61qLurvPKSQWW5CZMCYrP331LcUo/iBJ9/
                    vWS9BOfTZF22H7e/cdbUJ3BII+cH5qm99Nrkfgu0k8wUEVkHT/1B1rpZ1K7G6UlIIJZX5kK+xrYu
                    j/rrp2sKbY1i2/09/A8ZgBTfzHI9e/NaCm50BqLSSQttcCYzJ+1Crnpu/tJ3tiBW5LFm7bIdaX4r
                    biAtKkgQRHM95pL19CnQvYkR78mgsuetFJMEQRg4rgW6W+RJ+KOakxtMlPf0qubULRg1RBQVvEel
                    dBEwZqR62cbXKh8e1fGxMAgDNaZTNpOVHG7sBFVXDK1mMxAiryQEtkkfFV4/l7jncSR8VVRXTJrp
                    BkgASTXbdu5cr2oB+KOadpX8OQogKVkQoT/esNAumA+MsxCSkZq69iMZqnYuDxHYMAwdo7CrK17p
                    HetMoXcoJyYNL2r6aHV+Ik7QcEkYHvijr7wYQtalBKEpKiSYGKDsuvXbCl3CSEqUdiDyE5jijCWy
                    yolSY3BRnj571Im1DSJoobJCQSmEqJyAIE+lVnGd5IzI9cVFWU0VgoTBifuP3NaP9DupFWDrulOK
                    P4tzQBImcR61nDi1giPKUgplPp3+e9TaJqrui6qzeJOELG7sYmKE9a2KE3bCSpIaUgBI5BOP+P7c
                    0L162UlpSd8oM4Xijv0/W11FpDF8h1KwpA7TIj07c5+as9TW1qi32oSs4KTnn249q0y87dXluweU
                    FJDq952hOQTOCMDn4pBee8ZRSzZhRRKZBJVM+kTGa3i76JavnlHwPOeZ7fNV3egm7RryM7FtiJCR
                    wYJ/X+1BYQmwvX1pLrRSj3x/3R7SNJ8PlWMx3I9Mn7U76106plsqCIjJxQmxtwpwTgTmRSl7S7Rt
                    gAwVexAij1u4qNqd0HkJH+aHtlLSBtTuj14rrx3COYEQAKQLOXbdm2UrHjOD8O5RIT/zSN1PrRWo
                    MNmFH8RTV3XdVTYsKSDLq8JE0kgqcfU44Sdxkk5BFZtKRT6gUtpWQCkAjtSo4khxYBMSRTKBDogn
                    nv3pdfP81WTyTmgqzidxA4Hr+/3irFomQQCpJHB9DUMknaDImQP81dQNiAAnPzxSm6/Q3q7/AFXS
                    ndGuV/8AyLU7k7jkpJz+Rz96er+wS68YkbuJMCa8v9KdQv8ASfUdrqDSgdi4Ug/1J7j8q9UW9+zf
                    2bFyyd9u8kLSr1BzTf0EjqzSjaWS3SnjM/elm3R4m1HB7GK1Tq62TddPXZSIKUFX9qzC1TuSnkY5
                    9aQseCh1HnTjiqruiFXmZMEZ2miDaCpQAgDgVeaRCZIxGaUVbhhbTRSQQR27zVix0N69WlCEK91E
                    YnvXPVXUaNMLSEMh1batxPH2rQuiup9J6vtElhSWrlCIVbnHHcUdoEtenP4JG0p88SVRXwWqgfKA
                    nvu703apbKtHd5GDAB7+/wC/eh14EBmPDhRO45kH9/4rJZLp7gLa1yVEmKnU4T/1Q7S3CbJsnvJk
                    VdAwT/TxSFRdv/Fvhb3nbbVLaTxM8x7RivrunruBIc8NKMkq4jvnt80QtrZVwqP6ab9J0BlVuUPM
                    pdQsbVJWkEEd5BpnK+FXSejw4oqccW4k87ySKs6t0AbpRdC1FZzJx9/atGbtWgkAgfEVYW0hbCoI
                    SDiteo1gd70nqFsdyEFcZMZpevLR1sFC21JWOxTzXoq50lBgiB7gc1Vv9N0Swt/H1hy2tmOAbkpT
                    u9hPP2rPrWtC/wDxi66dt7p/RH3EpKTLYWOx7fpW8ajpStSuJKUpUfxKSIivMtj1B0vYdUM3/Tdj
                    cuXNuoFT4lLRHsFeuB2rW+nf/IzpzVLtdnqCzpN+hRQpNwnySD68Cso8N6OzatpSAF7J8x57T/Yf
                    pVS7s/HBASI5EUXZumNUShy1uG7ptfmS40oKCh8jFWf4IKUDtSFen/FOjGfalobdw0tG0EHAiDNZ
                    i/pJstQeZUk+VUV6Ge09soUSD3gqGKzXrvRhaX6blI8rghXzUiSpoTAHvwD++9UdQuEWTK3VwkAY
                    o26jwgVHjkx6VmHVuunU7xbLKoaQSCeJPpVSH3t6vV9QKlHyhXzHvU92tKUgCCkJjEUNsoZ3boCj
                    gRmp0uqKSTClE9881kvqZXClxI/Ol+5aKVnHNHynyxkqx2oXd2yy6ZEkH8vvSgxoBOSMCraHfMZH
                    3nNRlvYk5nHf4qJwlCuZBwYqCS6AWDzI796276I9UK1HSXdFfWS/afzGYPLZOQPgmfuaw1S1lBOI
                    HPFE+j+o3emuoLO/aJAbVC0AkBSThQPyDUnq26R/FaXdNFOPDVPzBrLGGgSJE1qbVw0/pqLhlRWw
                    80HG1eoIx+lZm0dpODWoF+1ZwMQfaqXU2tt6Fp0jzPL8qEgd4rq41RuxtlvLO0IHc0h3V4/q145d
                    vqJ3fhTuPl/YqtxSA+ovOKYcWslTizJn1ihenareaPft3Ns8ptaTPlURPpNT6qrZtbKiD3APf0qm
                    2hKgpRPwOwrMab70d9T2Op7UWt4fBvUoCQVAQujVyClEEbVf4rzcw6q2dQ60ooWkyFA5BrVeiPqO
                    NUZbsNUIDyRDbpPPtT2z0XbBsNWrYSkgBIHI9PXvRK0snLlwBQGMY7f91Bp2nu3q0AhQgDnmnK00
                    tNlbhSwlpKRMr8oHec0yakNjpgaCSQDEGmG2dDbQ5n1pI1f6m9N6F5ReHUHwP/VZp3CfdRx/ekvW
                    /rbqd6hSNOtWtOaOAtR8RyPnA/StbPEZa2a91FqyaU/cvN2rI5cdWEj8zShrH1r0LSklm1U9qrwP
                    4WBtbn3UefsDWGatq95rbgdvLx65Wc+dfHxVGYBjyj/bPFZvnWp4tD1z629R6sFIsizpTBBEMIBX
                    91nM/EUnMi71u9L1y67dPKyp1xZUT7kkzX6w0xy5UP6U+kRTZo+mBgGAJIgeWZrO2nMMOh2zWm2j
                    IQgNFTm4gD8UD/ul/wCoOjBT41FpI42q2x+v/PxTKxZuvp3CEoQkQT9zUt1YrubZTTkKSscetCZz
                    ofV2q9PvBel6hcWbqTJDbhg/I4Nax0x/5R63pu1vV7djU2uFLSNizjmsf6i0F/RrneptXgOTsWRz
                    QweYA96C9j6F/wCQ/SvUDaULuTp7v+24SQkHj8X+TRbXlW+uaQXbZ9q5b5S4ysKTj3H5V4kC9o9+
                    QZq5pmuX+nXAXaXdwwoHBbcKVUy4Ma79Qerv9Oa/gLZU3CsqUn+kVmSXSUwZJFaB0907adWWCbu5
                    S6q5XIWsK5V96uO/Tq0QZHigfPFIZ/bvAeUpO6PSrTZAV+GJ496Z19GW1qolK3CfeKgVpKWiQlJM
                    evFSCkNlxJ2ZB9KhurJQAURnuBk0a/hg2MDI7io3LZTwgDJHrUivcsbyEFOAef396oOslIIiTHPp
                    Tg/od05ISyVJwO/FU3OnLkJg261HsCJ/vUix4Pc7T6giqziAFK2rBz/t+aP3HTN+qdrC/wAoqi50
                    3qSebZz22pqLY/on1aNV0F/Qnl7n7OVsT3bJ8wHwTP3PpXVxDb7wBCQlahPHess6WXqfSmvWupN2
                    zyS0vzeUpCknBB9iJH3p16v6gZKlt2ZJQ+fEKzIIkTtIpGBevasL58NBX8lOfmqZugsAJ8iAPzqg
                    jctRJmrKG1BE7cfFZIRqSRuWoAAkyfeqC5bCsAZgA0TvigKyDHtnvVBSklMrJg+1KdIRuAI47TUo
                    eI3qWs7iZkczU7CA40ABuAH7+9VltEqhJM8RwRUGgap1Tr+ms/wumdPLttsRcPJ8Q8cgYH5zSBrw
                    6q1tc6mb19JyEKwgfCRgflWk9G9es3CUadqpBP4W7pXI9levzTq7oaHSAEhW6CkiCCD3BpTzKvQ7
                    4pIFmtCyZ3bSD8elfWendUeWhtFq4txStoSEklROAAP3zXpZPS6dw3NyFHakRk5ru56TaCARbhKu
                    +8H/AIx60YdeZWdDuUrIUwqCedvNGLDp4jaXRkdq1XV+nFW65GI7AGlW6tCw7xjginBoczZhtWAB
                    8VfYbJgcZmvjIAJnn3qdTgZSpwf0IKvkxj9aIUljcqC3yFfiURI9BgVMu6UDzkVQam1tGyQFbUwT
                    7/8A3NcKfCuD9j3qD9q7QvLZSFEweaQH7ZVo+psgwk/nTu69giPL88UI1fT03TW5AJdGQP8AcKCW
                    1OebIGM8VJZDJJAJj3r8phQJRwD61bt2UtNpED0M1Fqf0d1jwxc2SoO0hafbsYrRb93BKQCD2jFY
                    f9PNQTYdU2ySsbXD4Zn34H5xXoX/AEZb7W+U7Y9aWaTbslyYRn1ihdygD/8ATFNl/Zoa3CIjmgN2
                    1uEioFy4WlE+WfmvrG1SfwAVJeNkkYODU1jbFWDiKoVhhrG6MmrzaV47RyZNTM23l8smrRsSECe2
                    SD/atDVdBBAncSDxVtpllbRKkpSjkzQ50eAhTrq/DbGSVYpH6r62VfpVaWBU0wBClD+o9/tVuLBP
                    q/rOytUuWlglK3YguJSMfFJQvHrlSfGWVjsCcD4qkEBEKIEkZ98V0lZJEA1nda6G2Fp4Bmr39B4+
                    aDWzyQZmQDE0QL8NyM1JRv20rTlJOCKGFCQoEq7dhNWnnlPOKTuIjFT2dn4qklZ8pzJ7+1Qc2Nmt
                    0BKODzNGLbS0MQpSQpfcmrVsyw2gbEgR3n/NSEgqJCoIpROcAScYHPxT79P/AKlK0UpsNTSp/TlE
                    AK5WyfVP/FIi21f/AFXEk/iMH3NBesNO8G/s27lhQeZc8yVNkkEd/vx+VE3bFstKcC20pUoykEwI
                    5E/vnkV5o6C+p950NeJQ4DeaWsjxLZSsDPI9DXo/Qtds+qNOavtNcTdW6hCkcqT2IUOZzW5dZwnd
                    QWpcUsBGwJnzrH4vUR+dZn1FaFsbx65rW9dYVa3L6FgpQseVJJjb/SR+VIPUNmHWnQR2xiKzTCIk
                    iJA7124dyEI7uOAfIHmP9qiQTvIzANXbZKVOpmQEJ3cYn0oKK4WpSRuMj/bA/tQ91zbuKQFAcn04
                    q/eQVbpgqHb0oa4hRhMZIwKEi8UqESDjInkd6hDpSracpP3qZGnP3RAZKjPcAic0bs+kNiELcyuP
                    tTg0rXliQFXCU4H4kx+tC3HlJV6DvGK0y30xTS9hA28Cf1pb6k6PXaNOXFv5m+VIjIqxaV27hbD6
                    HkGCCFAzwRmvU3QfUzXUvTFvdpI3lIS4AeFDkV5XDZKCIMjArSvoZ1QdL1h3SnlSxdjc37LHb8v7
                    CqG8xr2ttFUkAgzmly6bBnGKcr5sOCf6DISSZnPP5zS1ftAEiOOZqBSvkf8AyQByBOKs2u1KtvPc
                    1WuBvuFlPbANTWh2kSSDzipGHTwfERgj0Peo9d1+y6cslXF4oBQ/Az3Uf2RQrWOpl6RaqbsrZd5e
                    KwltuTs+YrPLjpjqPqC7/i7xte9cx4nlSB6AVq3Bitr/AFbedQ3Si4fCYJlDKMY96GCFe3sabrL6
                    Xag5HiOBM+gpgsvpI3tl1wk1ntpmhRAJIkivqGHXVfy2VEx2Fa4OgLKzEhnee5NRv6W3Zj+U2hH/
                    APkU4NZYnTLoZ8NQB7miLdooISHJ3f2prvd+QATjPtQl1hS1gmAqPSoaEC3b8Y+3b/NXGEhXoYHI
                    HP7zVa63NODykjOVVPbqKkwTIHAPalLjcAY7emK/buQO1cNEhOMD0FdIJMgZ7+lSAVp8p4PxUC0A
                    mpHXNsziBMzVBy/TlIAI9zWWnToyTgn1Aol0V15qv0/1dN5YOyiSHGFZQtJ5BHegiroqKp4PqcGu
                    WkhxPEjMVJ6eZ6tsOubJGq6cQFJQA9brVK2THBnkEnH5R2oJqNqHAQMisW0LW7vQbxD9qspUOUzh
                    Q9CO9bHoHVNl1XbFSIYuAIWxPHx7VVM31C1Vaak82oEeaQPY1aZbIbUtMTEE+37/AM0V63042eoN
                    PEYUMkdj+4qmkDwEiBu7gZqQa5bLUsZIPMwMVdsdEXduoAkAflRbT9BduCFOJKEcgd6ZLa1Fqja2
                    AkpxxUFGw6fRapASkExExRBOihxMlAx3FWrZtTjwKgTkT6ijbdv4YGDJMEHt+4rUFLbmghwmSCo4
                    qu7oqgVJWNw483NOjdsHwCBAHMg55ri70dVxbKQ0txhyZ3hAJEc8yOB3pxMI6z6LOmururZuGyZU
                    gdqTLe5d029Yu2Flt5lYWg+hGa9RapoCXGil4IU2RhQyAOJ96w/rrohelXC37dG5k5KQJA9xWaY2
                    fpvW2dc0W0vkgBu4bCyCZCFcEfYyPt71X1RSUtKISUwOSInkVm/0W6iKVXWjPLAJ/wDkMFQmP9yR
                    7ZB/OtE6je8NpYhKTgds5rJK6WioeUYVJEd81T1a+b0W2HiLAfXOxAifmjV5f2fTHT51G9IXMhhk
                    GFOK7AflJI4+ay66v39Vu3bq5cK1r7cBI7CK1eAksuub3p/WVvbg+wuC40o8/Fbl0Tq2k9a2SH7R
                    5BUhMLt1DzoPx35rzZrCPOFH0iodI1jUOntRbv8ATrhbL6CICDlXtHehPYSdJaKE7I3HjIyfavjl
                    htyUEEdgORSz9LfrBYdYMJtLpKLTV0gpU0YCHD3gf4p+dQ2o7oClcTif0rTJSvGNqVAD2yKXbuz3
                    qjaT9qeLxjxSZOewmaC3VmEHace01Ii3GnFDm5OPig19aKSsQnB7U+XlokGQBnmO1Leq2/8AMAIi
                    olt/Tg+1uCQSnFC/C2LKVNgbT2puZY29sUJ1ezglxP3ipQKIEYx7V+QYGOD+tQ7oJE1Yt0hShPbN
                    RJFxe+K0vcNqlHKfUelDi6EKlUKIP4e1cErUUeJJ7AD86+bCogbYzmcVhpKl9SiAqM8iKIsQEyTE
                    1Vt9MdcghBEcntR3T+nVukBxMEikKgWAMEfYzXdhqj+mXaHrdxSFpOCk0yMdNMpSCRk9qv2+g2be
                    VITA9TViFFdWsdWaS03dNlm7QQCoJhJHr7Ue0W00e1CXbjULRxzkS6nHExmkPVnmmLVbbO0I4MH9
                    x/1SpeaMrZ/FW7hVElWTg84qT0QldoUy28yoTwHBVdSkkwmIHoa82MXV2yryvOonsFESP2B+VXE6
                    zftz4d/co7x4h/SjU9MafZl4pCYMQRPEmmG3sQWyFiT6ngj/ADzXk0dT62gHZqt0lPs4atM9fdTM
                    Jgazd+pKlkmfvTLix6wUtlLauWyDt9Sk8cfNcJeBWENhKxJCEgYJk/rj4FeZLf6qdSslO/U3nCOZ
                    VVlr6v8AUQUIuyRxCgCO3M/Ap9lj1GW/4xB9Uk+cEQnM57TMUra/08jUEKJaSJH4VGeZP/Pc1htv
                    9dOqLQKDb7YSo7j/ACk5nmcZog3/AORPU20h9qxugSVHeyZk85mq2UYodUdLXfQ2vsatZA+Gy7uO
                    3jnP2Ip61rW7a6sba+UrwbRaQ8pQyUp7/eZ+9J1z9abzV0lq+0uxeSrBCG1Jn1EbjzxVRwP6hpLY
                    ZbW3atL3pZB/Ce3zWWlXqXWrnqvVf4m5Bt7dgbbe0Jw0kdvnkzQ8kIiTCakMoEHHzVdy43kxkDsa
                    Cp6onexuxIJ49KCgFxcDM+tMF8UqtlCYMc0vNuAPBMgdhNLLv+ZZ3CH7ZwsOt+YLSTIP2rePpb9b
                    29Q8LSdfcCLhPlauVQN3sr/msRO0IKQQSeDOTVZ22BCFJJGZEYj9xTKrHtB53xApSUhSTBCselDl
                    tpWruTWJ/TT6vr0dTWl62tT1iTtauP6kds+1bky61dW7dzarDrLglLiDIP3FaZBLxgMpUojEdqVN
                    UG51OIp81BseEcGcnPekbV2yLoSCJyIqSnEAVTuE70lJ4NWlzEHAFVVYophW1C1VavGcpOQa+sfg
                    wYgZ/Ojt8w3c26gqAQJSr0qlpWiO36ilCkoSkwSf+KCzZNp4ikpIxIkxM1ctLVG9IKZ/3AYr6lsp
                    IkK3J5k4jiils2grB4PpHB4pSzZWhabSVpBSIAjIoql3YnaEjy5MCIqowgKjlSgI2x6+tW207TjE
                    RmlLYeKgOMVU1O8LFspcjf2E1YbX5SSdoA/EaWdX1QXF1sQZQk4HrH+agr31+49DOVAGSr1J/ZqC
                    1vy04kk4nsf0qLaVEEGDzPY+lQhCm0TmMySnislfu7K3v9zlupKXiJ28AmJoItpTLhQtJSodiKvl
                    9xlY8wIGU9wRnNSvqauU/wAxMKGJiDQQwyoAqx6GvrbhbUkiCd0+YSKjuWiyNxPiIONyeZ+KiYUQ
                    ZGe00Jc8MkEkgdsmufCxxXCHCOB7jBxVtAC20mP+6UgWlSgEknakQATwPb8zXxtla1BKZBPpVxu3
                    Lhxz7dqIMIas05O5XsM1JHY6aLVPiKAK4kyOKbOlrtLtu8EZSDg+v7/5pSursKb5GAcAd6M9CPKX
                    YutrVKG1wmDhPrUhrVdGZuklSIQo94pNv7Z2xdKVjbPc96fFrCgSIoPq7SLlva4Dxz6e9IKNy5uS
                    pIM47TFBXLcpUSYOYntRm6tiySkGYyMcCqRSdsR9vepKqN/iyCTOcen7FT+MlYAP4U8xUZMzgZ7f
                    v719gTuVJnFSflwQSJwZkU4/T/6mX3RzoZdWbnTifM0pU7fcelJwMBQKpB9DUYUYAKZ9vWpPWWma
                    9ZdQ2CbqwdS4kgbhOR80u64N18qY9MVhPS/VOo9K3getHCGv6kdjmYitK1L6mWN/ZNXaUOB9aYLI
                    T/V81rQL3DeSfagmoavb2aVBSxuHYGlm96zuNQQUeKttKs+C0nIPuo/4BoS4+hbBUYU+VJgq9MzH
                    b059azaZF/UepnLnchryASJ5oPba7qGnXJdZuFggzBMivrqWi+oshXhFR2lwQSJwSBMYqu62FOwf
                    tQhe5slOkFsYjKu1dtAtxviJGAOcUYcaSpSglG0dh7VVctVOoJCAoH1mthbtUy0VCSP91TIkH5qG
                    3BQ0MkyZMiM1MDAJ7igqmq3hbZLSQIVgmYk+lL9lb7j4k7pAMke/aKKaiS/cGIGYGc8Z+P8A6rhE
                    AbUpAAxA4opiNy3KAVAlKwRxjPI96oPNoQjaU7grAAPJnt+tFXVhQVuMdoInNDb1xCCFlZxHOY5/
                    Ogqb4Q87CAlAGc5/X86+IIT5dpIBg7jjv+VSLbS0UFRT2I7/ANqmZa8YqCSSqZSZ5H7moqoYN0Vb
                    U+QiCP8AcM49z++1VTphZdIC4RMgrPFHWbdKcqUqT5sDGP8AOIj5qG4BU0STIHfOfaf2KgFBAQUh
                    SgDzB/fxUzCg6oSZJEiRX7YJPr/tGcnj5/tVZZKSI80COBHHf9KgIrvEoBDahIxnEiqztyFAzAOT
                    gT7fv4qipU+UkgRMTwf81IlClRGZwQR7UhM45IUoK5yZjGJ4j9zTf9PLB2+sHy3tgLzOKT3LZSsG
                    NxxKoEYp3+kl0EXN9bE4IBHYUoyq0dxHl3Ce8UMvtO2DmTxkU2XBgEzQTUU7wfegEvUNPS4pW0So
                    nA7fl++aGK0ooCtyZBxnuaeGtOUVg5EGQa5uNJC07CkA9jxSiD/ApA3FG6ZCh3BqQWjSBloRGJo1
                    rWjuWyZSjy9wPkUKdIKeSkjBBzmlPjTbQUNrSR7RVkFsEwwiK4YcDSt3JEQD81IiARCTP5VJ34qQ
                    NyW2xHoJq5YWbd5aKDjSY9QIz7VU2BZEcntTFpzSTapQlGUjaczPcmiopXukOWjhUkSn2qsUwrIi
                    nm6t0kQRPqKAX2kRK0cHMVkhCUyRmoHmzumKIBgpgelcONT80o5bACSDn+1StWgIyd0Gp0MSIBGM
                    8VabYCU+vcZroyH3ll5PESIV3AHNDFueGndkR6CmR1TbTZUtSUpHckZpXv8AULF6+SwHkW6Vk+ZR
                    wKxeGg1w+M6VQAr5rlKCj/BNOFr0bbvMh5u4/iEKzLYxFW2enLZofgGOSo0IkeAp0bSkq9QBUyOn
                    lPSfBJJOSadhYtNklKEifav27ZwkGOKCSbvpR9xO8FLIEmB3/KoG9LbsgEKUEwCDE/5yMU8qh5Z8
                    gBPJHeh9zpyXFGRM9vzrQ0uoYbtVfhUqEnKcAnv/AGNRhpK4KmylKSRuIk8yf70YesUKVACUI5Md
                    /wDr9+tDTbJaUUyrMz3xiPirEFXDaWXVCE5JCtw9uP361ArTP4lJLapUD+BXvP7+1MAtwpI8oAj8
                    UHHE4j9KtsWO1KZTGQZA9/iagR16e8gQtpSUzMEEj/uu2kpXvxBgDH2rRP8AT21o2qQCmOD2oLqP
                    TewlbGTkkVVF3wkqUVOSonzK9STRTop82PUqBP8ALcER75qhcIW0T4iYVOa5s7o2moW7yf6V5McC
                    otefWfMSZ+apItzdv7YqV57e2kjIUAQfWj/TujFdv4ik+ZVUAY1ph5CZ9cVK5pI2FW0wM4En8qaP
                    9MjHBHYGuVWKkZgkDkRW8ZKT+jofaKVgH570jdT9IKsNz7KSW+4A4rXlWZC1RJPpGanOjs3lsW3U
                    eUiOOZFGHXnad6YSJA5z3r9ugYWSPenDrzoJ7p95VzboP8OoyY/pNIqnigpSc98nigiLLsrAPr3+
                    ab7Pci2bGdnO7mSeaQ7JTj2oMMhKjwQOOe9aAtYQyEj49qKVdxRK/wAW7HzVFxSePTvVm4XCYj7k
                    1VSypwmAYoSm6wCZFVXW8/8AFFjaFHJqB213JwINQf/Z";
        }
    }
}
