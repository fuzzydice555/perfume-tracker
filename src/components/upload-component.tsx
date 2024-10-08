import FileSelector from './file-selector';

interface UploadComponentProps {
  onUpload: (guid: string | undefined) => void
}

/*
4. Security Considerations
Validation: Ensure you validate the fileName to prevent path traversal vulnerabilities.
Size Limits: Implement checks to ensure files are within acceptable size limits to avoid Denial of Service (DoS) attacks.
Error Handling: Handle potential errors and edge cases, such as file upload failures or issues with the microservice communication.
*/

export default function UploadComponent({ onUpload }: UploadComponentProps) {
  const handleUpload = async (file: File) => {
    const res = await fetch(`/api/upload-image?filename=${encodeURIComponent(file.name)}`, {
      method: 'PUT',
      body: file,
      headers: {
        'Content-Type': 'image/jpeg',
      },
    }); //TODO: what if not jpeg?
    if (res.ok) {
      const json = await res.json();
      onUpload(json.guid);
    } else {
      console.error('Failed to upload file');
    }
  };

  return (
    <div>
      <FileSelector handleUpload={handleUpload} />
    </div>
  );
}