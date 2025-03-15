# Texture Size Changer (Unity Editor Tool)

This Unity Editor tool allows you to **change the max texture size** of all textures in your project, while allowing you to exclude specific textures using an easy-to-use editor window.

---

## 📌 Features
✅ **Change Max Texture Size**: Select a size and apply it to all textures in the project.  
✅ **Exclude Specific Textures**: Add images to an exclusion list, so they won’t be modified.  
✅ **Easy-to-Use Interface**: Add/Remove images from the list using a simple UI.  
✅ **One-Click Apply**: Press a button, and all textures (except excluded ones) will be updated.  

---

## 🚀 How to Use
1. **Open Unity**.
2. Go to **Tools → Texture Size Changer**.
3. Choose a max texture size from the dropdown.
4. **(Optional)** Add textures to the **Exclude List**:
   - Click **"Add Texture"** and select the textures you don’t want to modify.
   - To remove an image from the list, click the **"X"** button.
5. Click **"Apply to All Textures"** to apply the changes.

---

## 🛠 How It Works
1. The tool scans all textures in the project using `AssetDatabase.FindAssets("t:Texture")`.
2. It checks if a texture is in the **exclude list**.
   - If it's **excluded**, the texture remains unchanged.
   - If it's **not excluded**, its `maxTextureSize` is updated.
3. It updates and saves the modified textures using `AssetDatabase.ImportAsset()`.

---

## 📥 How to Install
1. Open Unity and go to **Window** → **Package Manager**.
2. In the **Package Manager**, click the **"+"** button in the top left.
3. Select **Add package** from Git URL.
4. Paste the **"https://github.com/EmiroDeve/easy_texture_resizer.git"**.
5. Click **Add** or **Install** to install the tool.

---

## 🎨 UI Breakdown
- **Max Texture Size Dropdown** → Select the new max size for textures.
- **Exclude Textures List** → List of images that won’t be modified.
- **Add Texture Button** → Add new textures to the exclusion list.
- **Apply to All Textures Button** → Apply the selected max size to all textures (except excluded ones).

---

## ⚠️ Notes
- This tool modifies **all textures** in the project except the ones in the exclusion list.
- It only works with **Texture2D assets**.
- Make sure to **save your work** before applying changes.

---

## 📜 License
This tool is free to use and modify. 🚀
