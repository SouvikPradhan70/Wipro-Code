// Step 2: ContactManager class
class ContactManager {
    constructor() {
        this.contacts = []; // stores all contacts
    }
    // Add new contact
    addContact(contact) {
        this.contacts.push(contact);
        console.log(`✅ Contact with ID ${contact.id} added successfully!`);
    }
    // View all contacts
    viewContacts() {
        console.log("📒 Contact List:", this.contacts);
        return this.contacts;
    }
    // Modify contact
    modifyContact(id, updatedContact) {
        const contact = this.contacts.find(c => c.id === id);
        if (!contact) {
            console.log(`❌ Contact with ID ${id} not found!`);
            return;
        }
        Object.assign(contact, updatedContact);
        console.log(`✏️ Contact with ID ${id} modified successfully!`);
    }
    // Delete contact
    deleteContact(id) {
        const index = this.contacts.findIndex(c => c.id === id);
        if (index === -1) {
            console.log(`❌ Contact with ID ${id} not found!`);
            return;
        }
        this.contacts.splice(index, 1);
        console.log(`🗑️ Contact with ID ${id} deleted successfully!`);
    }
}
// Step 4: Testing the ContactManager
const manager = new ContactManager();
// Add contacts
manager.addContact({ id: 1, name: "Souvik Pradhan", email: "souvik@example.com", phone: "1234567890" });
manager.addContact({ id: 2, name: "John Doe", email: "john@example.com", phone: "9876543210" });
// View contacts
manager.viewContacts();
// Modify a contact
manager.modifyContact(2, { phone: "1112223334" });
// View after modification
manager.viewContacts();
// Delete a contact
manager.deleteContact(1);
// View after deletion
manager.viewContacts();
// Try deleting a non-existing contact
manager.deleteContact(5);
