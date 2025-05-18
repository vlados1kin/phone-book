import React, { useEffect, useState } from "react";
import axios from "axios";
import "./App.css";
import { FaEdit, FaTrash } from "react-icons/fa";

const apiUrl = "http://localhost:8080/api/contacts";

const initialForm = {
  id: null,
  name: "",
  mobilePhone: "",
  titleJob: "",
  birthDate: "",
};

function App() {
  const [contacts, setContacts] = useState([]);
  const [showPopup, setShowPopup] = useState(false);
  const [form, setForm] = useState(initialForm);
  const [errors, setErrors] = useState({});

  useEffect(() => {
    fetchContacts();
  }, []);

  const fetchContacts = async () => {
    const response = await axios.get(apiUrl);
    setContacts(response.data);
  };

  const validate = () => {
    const err = {};
    if (!form.name.trim()) err.name = "ФИО обязательно";
    if (!/^\+375 \(\d{2}\) \d{3}-\d{2}-\d{2}$/.test(form.mobilePhone))
      err.mobilePhone = "Номер должен быть в формате +375 (XX) XXX-XX-XX";
    if (!form.titleJob.trim()) err.titleJob = "Должность обязательна";
    if (!form.birthDate || isNaN(new Date(form.birthDate).getTime()))
      err.birthDate = "Неверный формат даты";
    setErrors(err);
    return Object.keys(err).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!validate()) return;
    try {
      if (form.id) {
        await axios.put(`${apiUrl}/${form.id}`, form);
      } else {
        await axios.post(apiUrl, form);
      }
      fetchContacts();
      setShowPopup(false);
      setForm(initialForm);
      setErrors({});
    } catch {
      alert("Ошибка при сохранении контакта");
    }
  };

  const handleEdit = (contact) => {
    setForm(contact);
    setErrors({});
    setShowPopup(true);
  };

  const handleDelete = async (id) => {
    await axios.delete(`${apiUrl}/${id}`);
    fetchContacts();
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm((prev) => ({ ...prev, [name]: value }));
  };

  return (
      <div className="container">
        <h1 style={{ textAlign: "center" }}>Контакты</h1>
        <button
            onClick={() => {
              setForm(initialForm);
              setErrors({});
              setShowPopup(true);
            }}
            style={{ width: "100%", marginBottom: "1rem" }}
        >
          Добавить контакт
        </button>

        <table>
          <thead>
          <tr>
            <th>ФИО</th>
            <th>Номер телефона</th>
            <th>Должность</th>
            <th>Дата рождения</th>
            <th>Действия</th>
          </tr>
          </thead>
          <tbody>
          {contacts.map((c) => (
              <tr key={c.id}>
                <td>{c.name}</td>
                <td>{c.mobilePhone}</td>
                <td>{c.titleJob}</td>
                <td>{c.birthDate}</td>
                <td>
                  <button onClick={() => handleEdit(c)}>
                    <FaEdit />
                  </button>
                  <button onClick={() => handleDelete(c.id)}>
                    <FaTrash />
                  </button>
                </td>
              </tr>
          ))}
          </tbody>
        </table>

        {showPopup && (
            <div className="popup">
              <div className="popup-inner">
                <h2>{form.id ? "Изменение контакта" : "Добавление контакта"}</h2>
                <form onSubmit={handleSubmit}>
                  <label>
                    ФИО
                    <input
                        name="name"
                        value={form.name}
                        onChange={handleChange}
                    />
                    {errors.name && <div className="error">{errors.name}</div>}
                  </label>

                  <label>
                    Номер телефона
                    <input
                        type="text"
                        name="mobilePhone"
                        value={form.mobilePhone}
                        onChange={handleChange}
                        placeholder="+375 (XX) XXX-XX-XX"
                        title="Введите номер в формате +375 (XX) XXX-XX-XX"
                    />
                    {errors.mobilePhone && (
                        <div className="error">{errors.mobilePhone}</div>
                    )}
                  </label>

                  <label>
                    Должность
                    <input
                        name="titleJob"
                        value={form.titleJob}
                        onChange={handleChange}
                    />
                    {errors.titleJob && (
                        <div className="error">{errors.titleJob}</div>
                    )}
                  </label>

                  <label>
                    Дата рождения
                    <input
                        type="date"
                        name="birthDate"
                        value={form.birthDate}
                        onChange={handleChange}
                    />
                    {errors.birthDate && (
                        <div className="error">{errors.birthDate}</div>
                    )}
                  </label>

                  <div className="popup-buttons">
                    <button type="submit">Сохранить</button>
                    <button
                        type="button"
                        onClick={() => {
                          setShowPopup(false);
                          setErrors({});
                        }}
                    >
                      Отменить
                    </button>
                  </div>
                </form>
              </div>
            </div>
        )}
      </div>
  );
}

export default App;
